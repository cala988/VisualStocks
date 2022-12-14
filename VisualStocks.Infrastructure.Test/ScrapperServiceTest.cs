using FluentAssertions;
using HtmlAgilityPack;
using System.Linq;
using System;
using VisualStocks.Infrastructure.Services;
using Xunit;
using System.Drawing;

namespace VisualStocks.Infrastructure.Test
{
    public class ScrapperServiceTest
    {
        private readonly ScrapperService _scrapperService;

        public ScrapperServiceTest()
        {
            _scrapperService = new ScrapperService();
        }

        [Fact]
        public void TestScrapperYahoo()
        {           
            string url = "https://finance.yahoo.com/quote/MPW/key-statistics?p=MPW";
            var doc = _scrapperService.GetDocument(url);

            doc.DocumentNode.Should().NotBeNull();

            var ValuationTablesxPath = "/html/body/div[1]/div/div/div[1]/div/div[3]/div[1]/div/div[1]/div/div/section/div[2]/div[1]/div/div/div/div/table";
            var dataTableNode = doc.DocumentNode.SelectNodes(ValuationTablesxPath);

            dataTableNode[0].Name.Should().Be("table");
        }

        [Fact]
        public void TestScrapperTableFinviz()
        {
            string url = "https://finviz.com/quote.ashx?t=MSFT&p=d";
            var doc = _scrapperService.GetDocument(url);

            string descriptionTableXpath = "//table[@class='fullview-title']";
            var descriptionTableNode = doc.DocumentNode.SelectSingleNode(descriptionTableXpath);
            var CompanyName = descriptionTableNode.SelectSingleNode("//tr[2]/td/a/b");
            CompanyName.InnerText.Should().Be("Microsoft Corporation");

            string valuationsTableXpath = "//table[@class='snapshot-table2']";
            var ValuationsTableNode = doc.DocumentNode.SelectSingleNode(valuationsTableXpath);

            var rowsNodes = ValuationsTableNode.SelectNodes("//tr[@class='table-dark-row']");
            for (int r = 0; r < rowsNodes.Count; r++)
            {
                var row = rowsNodes[0];
                string name; 
                string value;
                for(int i = 0; i < row.ChildNodes.Count; i++)
                {
                    if (!row.ChildNodes[i].Name.Contains("td"))
                    {
                        continue;
                    }

                    if (row.ChildNodes[i].ChildNodes[0].Name.Contains("Name"))
                    {
                        value = string.Empty;
                        name = row.ChildNodes[i].InnerText;
                    }

                    if (row.ChildNodes[i].ChildNodes[0].Name.Contains("b"))
                    {
                        value = row.ChildNodes[i].InnerText;
                    }

                }
                //var cells = row.SelectNodes("//td[@class='snapshot-td2']");
                //for (int i = 0; i < cells.Count; i++)
                //{
                //    Console.WriteLine(cells[i].InnerText.Trim());
                //}
            }

            doc.DocumentNode.Should().NotBeNull();

            ValuationsTableNode.Name.Should().Be("table");
        }
    }
}
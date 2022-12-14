using HtmlAgilityPack;
using System;
using VisualStocks.Application.Interfaces;
using VisualStocks.Application.Services;
using VisualStocks.Application.Services.Finviz;

namespace VisualStocks.Infrastructure.Services
{
    public class FinvizScrapper
    {
        private readonly IScrapperService _scrapperService;
        private readonly IScrapperTableService _scrapperTableService;

        public FinvizScrapper(IScrapperService scrapperService, IScrapperTableService scrapperTableService)
        {
            _scrapperService = scrapperService;
            _scrapperTableService = scrapperTableService;
        }

        public void SetCellsOfTableValuations(string stockTicker)
        {
            string baseUrl = GetBaseUrl(stockTicker);
            
            HtmlDocument doc = _scrapperService.GetDocument(baseUrl);

            string valuationsTableXpath = "//table[@class='snapshot-table2']";
            var ValuationsTableNode = doc.DocumentNode.SelectSingleNode(valuationsTableXpath);

            var rowsNodes = ValuationsTableNode.SelectNodes("//tr[@class='table-dark-row']");

            for (int actualRow = 0; actualRow < rowsNodes.Count; actualRow++)
            {
                var row = rowsNodes[0];

                string name = string.Empty;
                string value = string.Empty;
                int actualColumn = 0;

                for (int i = 0; i < row.ChildNodes.Count; i++)
                {
                    if (!row.ChildNodes[i].Name.Contains("td"))
                    {
                        continue;
                    }

                    if (row.ChildNodes[i].ChildNodes[0].Name.Contains("Name"))
                    {
                        value = string.Empty;
                        name = row.ChildNodes[i].InnerText;
                        actualColumn++;
                    }

                    if (row.ChildNodes[i].ChildNodes[0].Name.Contains("b"))
                    {
                        value = row.ChildNodes[i].InnerText;
                        actualColumn++;
                    }

                    _scrapperTableService.AddCellToTable(actualRow, actualColumn, name, value);

                }
            }
        }

        private static string GetBaseUrl(string stockTicker)
        {
            return $"https://finviz.com/quote.ashx?t={stockTicker}&p=d";
        }
    }
}

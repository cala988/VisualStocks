using HtmlAgilityPack;
using VisualStocks.Application.Interfaces;

namespace VisualStocks.Infrastructure.Services
{
    public class ScrapperService : IScrapperService
    {

        public HtmlDocument GetDocument(string url)
        {
            HtmlWeb web = new();
            HtmlDocument doc = web.Load(url);
            return doc;
        }

        public string GetInnerTextOfXPath(HtmlDocument doc, string xPathDemand)
        {
            return doc.DocumentNode
                    .SelectNodes(xPathDemand)
                    .First()
                    .GetDirectInnerText();
        }

        public string GetAttributeOfXPath(HtmlDocument doc, string xPathDemand, string attribute)
        {
            return doc.DocumentNode
                .SelectNodes(xPathDemand)
                .First()
                .Attributes[attribute].Value;
        }

        public void GetCellOfTables(HtmlDocument doc, string tableXpath)
        {
            var query = from table in doc.DocumentNode.SelectNodes(tableXpath).Cast<HtmlNode>()
                        from row in table.SelectNodes("tr").Cast<HtmlNode>()
                        from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                        select new { Table = table.Id, CellText = cell.InnerText };

            foreach (var cell in query)
            {
                Console.WriteLine("{0}: {1}", cell.Table, cell.CellText);
            }

        }
        
    }
}

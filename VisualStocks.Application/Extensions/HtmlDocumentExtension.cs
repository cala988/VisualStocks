using HtmlAgilityPack;

namespace VisualStocks.Application.Extensions
{
    public static class HtmlDocumentExtension
    {
        public static string GetInnerTextOfXPath(this HtmlDocument doc, string xPathDemand)
        {
            return doc.DocumentNode
                    .SelectNodes(xPathDemand)
                    .First()
                    .GetDirectInnerText();
        }

        public static string GetAttributeOfXPath(this HtmlDocument doc, string xPathDemand, string attribute)
        {
            return doc.DocumentNode
                .SelectNodes(xPathDemand)
                .First()
                .Attributes[attribute].Value;
        }

        public static IEnumerable<object> GetCellOfTables(this HtmlDocument doc, string tableXpath)
        {
            return from table in doc.DocumentNode.SelectNodes(tableXpath).Cast<HtmlNode>()
                        from row in table.SelectNodes("tr").Cast<HtmlNode>()
                        from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                        select new { Table = table.Id, CellText = cell.InnerText };
        }

    }
}

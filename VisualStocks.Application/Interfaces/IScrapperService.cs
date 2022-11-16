using HtmlAgilityPack;

namespace VisualStocks.Application.Interfaces
{
    public interface IScrapperService
    {
        string GetAttributeOfXPath(HtmlDocument doc, string xPathDemand, string attribute);
        void GetCellOfTables(HtmlDocument doc, string tableXpath);
        public HtmlDocument GetDocument(string url);
        string GetInnerTextOfXPath(HtmlDocument doc, string xPathDemand);
    }
}
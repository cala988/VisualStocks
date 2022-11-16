using HtmlAgilityPack;

namespace VisualStocks.Application.Interfaces
{
    public interface IScrapperService
    {
        public HtmlDocument GetDocument(string url);

    }
}
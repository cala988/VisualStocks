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
        
    }
}

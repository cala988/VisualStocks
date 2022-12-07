using System.Net.Http.Headers;
using System.Text.Json;
using VisualStocks.Application.Entities.Scrapper;
using VisualStocks.Application.Interfaces;

namespace VisualStocks.Application.Services.Finviz
{
    public class ScrapperTableService : IScrapperTableService
    {
        private readonly IScrapperService _scrapperService;

        private ScrapperTable Table;

        public ScrapperTableService(IScrapperService scrapperService)
        {
            _scrapperService = scrapperService;
        }

        public void AddValueToTable(int number, string value)
        {
            Table.AddValueToCell(number, value);
        }

        public void InitializeScrapperTableFromJson(string jsonTable)
        {
            Table = JsonSerializer.Deserialize<ScrapperTable>(jsonTable);
        }

    }
}

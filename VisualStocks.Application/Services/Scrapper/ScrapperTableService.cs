using HtmlAgilityPack;
using System.Text.Json;
using VisualStocks.Application.Entities.Scrapper;
using VisualStocks.Application.Interfaces;

namespace VisualStocks.Application.Services.Finviz
{

    public class ScrapperTableService : IScrapperTableService
    {
        private readonly IScrapperService _scrapperService;

        public ScrapperTable ScrapperTable { get; set;} = new ScrapperTable();

        public ScrapperTableService(IScrapperService scrapperService)
        {
            _scrapperService = scrapperService;
        }

        public void AddValueToTable(int row, int column, string value)
        {
            ScrapperTable.UpdateCellValue(row, column, value);
        }

        public void GetCellFromTable(int row, int column)
        {
            ScrapperTable.GetCell(row, column);
        }

        public void AddCellToTable(int row, int column, string name, string value)
        {
            ScrapperTable.AddCell(row, column, name, value);
        }

        public ScrapperTable InitializeScrapperTableFromJsonTableStructure(string jsonTableStructure)
        {
            ScrapperTable = JsonSerializer.Deserialize<ScrapperTable>(jsonTableStructure);

            if(ScrapperTable == null)
            {
                return new ScrapperTable();
            }

            return ScrapperTable;
        }

    }
}

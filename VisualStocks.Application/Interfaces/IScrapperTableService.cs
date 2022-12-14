using VisualStocks.Application.Entities.Scrapper;

namespace VisualStocks.Application.Interfaces
{
    public interface IScrapperTableService
    {
        void AddCellToTable(int row, int column, string name, string value);
        void AddValueToTable(int row, int column, string value);
        void GetCellFromTable(int row, int column);
        ScrapperTable InitializeScrapperTableFromJsonTableStructure(string jsonTableStructure);
    }
}
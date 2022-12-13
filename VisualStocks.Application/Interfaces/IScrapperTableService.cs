using VisualStocks.Application.Entities.Scrapper;

namespace VisualStocks.Application.Interfaces
{
    public interface IScrapperTableService
    {
        void AddValueToTable(int row, int column, string value);
        void GetCellFromTable(int row, int column);
        ScrapperTable InitializeScrapperTableFromJson(string jsonTable);
    }
}
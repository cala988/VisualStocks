namespace VisualStocks.Application.Interfaces
{
    public interface IScrapperTableService
    {
        void AddValueToTable(int number, string value);
        void InitializeScrapperTableFromJson(string jsonTable);
    }
}
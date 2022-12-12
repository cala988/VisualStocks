using VisualStocks.Application.Entities;

namespace VisualStocks.Application.Interfaces
{
    public interface IStocksService
    {
        Stock GetStock(string stock);
    }
}

using VisualStocks.Application.Entities;

namespace VisualStocks.Application.Services
{
    public interface IStocksService
    {
        Stock GetStock(string stock);
    }
}

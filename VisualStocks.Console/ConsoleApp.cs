using Microsoft.Extensions.Hosting;
using VisualStocks.Application.Interfaces;

namespace VisualStocks.Console
{
    public class ConsoleApp : IHostedService
    {
        private readonly IStocksService _stocksService;

        public ConsoleApp(IStocksService stocksService)
        {
            _stocksService = stocksService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                _stocksService.GetStock("QCOM");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}

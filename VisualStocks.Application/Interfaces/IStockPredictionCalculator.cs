namespace VisualStocks.Application.Interfaces
{
    public interface IStockPredictionCalculator
    {
        public double GetFuturePrice(int years, double EpsGrowth5Years, double price);

        public double GetFutureDividend(int years, double DividendGrowth5Years, double dividend);

        public double GetFuturePriceInBaseOfAverageSectorPE(double futurePrice, double AverageSectorPE, double actualStockPE);
        
        public double GetFuturePriceInBaseOfAverageStockPE(double futurePrice, double averageStockPE, double actualStockPE);

        public double GetFutureEPS(int years, double EpsGrowth5Years, double eps);
    }
}

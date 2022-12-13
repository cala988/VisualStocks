
using System.Diagnostics;
using VisualStocks.Application.Helpers;
using VisualStocks.Application.Interfaces;

namespace VisualStocks.Application.Services
{
    public class StockPredictionCalculator : IStockPredictionCalculator
    {
        public double GetFutureDividend(int years, double DividendGrowth5Years, double dividend)
        {
            return MathCalculator.GetCompoundInterest(years, DividendGrowth5Years, dividend);
        }

        public double GetFutureEPS(int years, double EpsGrowth5Years, double eps)
        {
            return MathCalculator.GetCompoundInterest(years, EpsGrowth5Years, eps);
        }

        public double GetFuturePrice(int years, double EpsGrowth5Years, double price)
        {
            return MathCalculator.GetCompoundInterest(years, EpsGrowth5Years, price);
        }

        public double GetFuturePriceInBaseOfAverageStockPE(double futurePrice, double averageStockPE, double actualStockPE)
        {
            return futurePrice * averageStockPE / actualStockPE;
        }

        public double GetFuturePriceInBaseOfAverageSectorPE(double futurePrice, double AverageSectorPE, double actualStockPE)
        {
            return futurePrice * AverageSectorPE / actualStockPE;
        }
    }
}

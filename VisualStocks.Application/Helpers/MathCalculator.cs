namespace VisualStocks.Application.Helpers
{
    public static class MathCalculator
    {
        public static double GetCompoundInterest(int time, double interest, double initialValue)
        {
            double interestPercentageCalculation = (interest / 100) + 1;
            double hightInterestYear = Math.Pow(interestPercentageCalculation, time);
            double finalValue = initialValue * hightInterestYear;

            return finalValue;
        }
    }
}

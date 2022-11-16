namespace VisualStocks.Application.Entities
{
    public class Stock
    {
        public string Name { get; set; }

        public decimal MarketCapBillions { get; set; }

        public decimal Price { get; set; }

        public decimal Dividend { get; set; }

        public decimal DividendPercent { get; set; }

        public decimal Payout { get; set; }

        public decimal PE { get; set; }

        public decimal FordwardPE { get; set; }

        public decimal PEG { get; set; }

        public decimal PS { get; set; }

        public decimal PFCF { get; set; }

        public decimal DebToEquity { get; set; }

        public decimal EPS_Growth_Next5Y { get; set; }

        public decimal EPS_Growth_Past5Y { get; set; }

        public decimal ROA { get; set; }

        public decimal ROE { get; set; }

        public decimal ROI { get; set; }

        public decimal TargetPrice { get; set; }

        public decimal SMA20 { get; set; }

        public decimal SMA50 { get; set; }

        public decimal SMA200 { get; set; }

        public decimal Beta { get; set; }

        public decimal WeekHight52 { get; set; }

        public decimal WeekLow52 { get; set; }

    }
}

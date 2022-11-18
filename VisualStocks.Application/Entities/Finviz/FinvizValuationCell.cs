namespace VisualStocks.Application.Entities.Finviz
{
    public class FinvizValuationCell
    {
        public string Name { get; }
        public string value { get; set; }
        public int Row { get; }
        public string Cell { get; }

        public FinvizValuationCell(string name, string value, int row, string cell)
        {
            Name = name;
            Row = row;
            Cell = cell;
        }

    }
}

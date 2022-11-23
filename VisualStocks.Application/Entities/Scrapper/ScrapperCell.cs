namespace VisualStocks.Application.Entities.Scrapper
{
    public class ScrapperCell
    {
        public string Name { get; }
        public string Value { get; set; }
        public int Row { get; }
        public string Column { get; }

        public ScrapperCell(string name, int row, string column)
        {
            Name = name;
            Row = row;
            Column = column;
        }

    }
}

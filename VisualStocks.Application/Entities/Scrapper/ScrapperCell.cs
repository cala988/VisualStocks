namespace VisualStocks.Application.Entities.Scrapper
{
    [Serializable]
    public class ScrapperCell
    {
        public string Name { get; }
        public string Value { get; set; }
        public int Row { get; }
        public int Column { get; }

        public ScrapperCell(string name, int row, int column)
        {
            Name = name;
            Row = row;
            Column = column;
        }

    }
}

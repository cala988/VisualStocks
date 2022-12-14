using System.Data;

namespace VisualStocks.Application.Entities.Scrapper
{
    [Serializable]
    public class ScrapperTable
    {
        public List<ScrapperCell> Cells { get; set; } = new List<ScrapperCell>();

        public void UpdateCellValue(int row, int column, string cellValue)
        {
            Cells.Where(x => x.Row == row && x.Column == column)
                .ToList()
                .ForEach(x => x.Value = cellValue);
        }

        public ScrapperCell GetCell(int row, int column)
        {
            return Cells.First(x => x.Row == row && x.Column == column);
        }

        public void AddCell(int row, int column, string name)
        {
            Cells.Add(new ScrapperCell(name, row, column));
        }

        public void AddCell(int row, int column, string name, string value)
        {
            Cells.Add(new ScrapperCell(name, value, row, column));
        }

    }
}

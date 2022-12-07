using System.Data;

namespace VisualStocks.Application.Entities.Scrapper
{
    public class ScrapperTable
    {
        public ScrapperCell[] Cells { get; set; }

        public void UpdateCellValue(int CellNumber, string cellValue)
        {
            var cell = GetCell(CellNumber);

            cell.Value = cellValue;
        }

        public ScrapperCell GetCell(int CellNumber)
        {
            return Cells[CellNumber];
        }

        public void AddValueToCell(int CellNumber, string value)
        {
            Cells[CellNumber].Value = value;
        }

    }
}

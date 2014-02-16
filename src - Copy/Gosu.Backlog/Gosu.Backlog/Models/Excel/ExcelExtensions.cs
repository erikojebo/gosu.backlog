using OfficeOpenXml;

namespace Gosu.Backlog.Models.Excel
{
    public static class ExcelExtensions
    {
        public static bool IsEmpty(this ExcelWorksheet worksheet, int rowIndex, int columnIndex)
        {
            var cell = worksheet.Cells[rowIndex, columnIndex];
            return cell.Value == null;
        }

        public static bool HasValue(this ExcelWorksheet worksheet, int rowIndex, int columnIndex)
        {
            return !IsEmpty(worksheet, rowIndex, columnIndex);
        }
    }
}
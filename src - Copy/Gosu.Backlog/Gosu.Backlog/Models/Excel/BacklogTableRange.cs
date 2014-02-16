using System;
using OfficeOpenXml;

namespace Gosu.Backlog.Models.Excel
{
    public class BacklogTableRange
    {
        public const int MaxRowIndex = 1000;
        public const int MaxColumnIndex = 100;
        
        public readonly int RowStartIndex;
        public readonly int ColumnStartIndex;
        public readonly int RowEndIndex;
        public readonly int ColumnEndIndex;
        
        public BacklogTableRange(int rowStartIndex, int columnStartIndex, int rowEndIndex, int columnEndIndex)
        {
            RowStartIndex = rowStartIndex;
            ColumnStartIndex = columnStartIndex;
            RowEndIndex = rowEndIndex;
            ColumnEndIndex = columnEndIndex;
        }

        public int ColumnCount
        {
            get
            {
                return ColumnEndIndex - ColumnStartIndex + 1;
            }
        }

        public static BacklogTableRange FindBounds(ExcelWorksheet worksheet)
        {
            var firstRowIndex = MaxRowIndex;
            var firstColumnIndex = MaxColumnIndex;
            var lastRowIndex = 1;
            var lastColumnIndex = 1;


            for (int rowIndex = 1; rowIndex < MaxRowIndex; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < MaxColumnIndex; columnIndex++)
                {
                    if (worksheet.HasValue(rowIndex, columnIndex))
                    {
                        firstRowIndex = Math.Min(firstRowIndex, rowIndex);
                        firstColumnIndex = Math.Min(firstColumnIndex, columnIndex);
                        lastRowIndex = Math.Max(lastRowIndex, rowIndex);
                        lastColumnIndex = Math.Max(lastColumnIndex, columnIndex);
                    }
                }
            }

            return new BacklogTableRange(firstRowIndex, firstColumnIndex, lastRowIndex, lastColumnIndex);
        }
    }
}
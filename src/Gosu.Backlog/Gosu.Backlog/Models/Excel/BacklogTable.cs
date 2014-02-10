using System;
using System.Collections.Generic;
using OfficeOpenXml;

namespace Gosu.Backlog.Models.Excel
{
    public class BacklogTable
    {
        public readonly IList<BacklogItemRow> Rows = new List<BacklogItemRow>();
        public readonly IList<BacklogColumnHeader> ColumnHeaders = new List<BacklogColumnHeader>();

        public static BacklogTable Read(ExcelWorksheet worksheet, bool hasHeaders)
        {
            return new BacklogTableReader().ReadWorksheet(worksheet, hasHeaders);
        }

        private class BacklogTableReader
        {
            private bool _hasHeaders;
            private ExcelWorksheet _worksheet;
            private BacklogTableRange _tableRange;
            private BacklogTable _table;

            public BacklogTable ReadWorksheet(ExcelWorksheet worksheet, bool hasHeaders)
            {
                _hasHeaders = hasHeaders;
                _worksheet = worksheet;

                _table = new BacklogTable();

                FindTableBounds();
                InitializaColumnHeaders();
                ReadRows();

                return _table;
            }

            private void FindTableBounds()
            {
                _tableRange = BacklogTableRange.FindBounds(_worksheet);
            }

            private void InitializaColumnHeaders()
            {
                if (_hasHeaders)
                    ReadColumnHeaders();
                else
                    AddDefaultColumnHeaders();
            }

            private void ReadColumnHeaders()
            {
                AddColumnHeaders(index =>
                {
                    var cellColumnIndex = _tableRange.ColumnStartIndex + index;
                    var headerCellValue = _worksheet.Cells[_tableRange.RowStartIndex, cellColumnIndex].Value;

                    return (headerCellValue ?? string.Empty).ToString();
                });                
            }

            private void AddDefaultColumnHeaders()
            {
                AddColumnHeaders(index => string.Format("Column {0}", index + 1));
            }

            private void AddColumnHeaders(Func<int, string> titleConstructor)
            {
                for (int columnIndex = 0; columnIndex < _tableRange.ColumnCount; columnIndex++)
                {
                    var title = titleConstructor(columnIndex);
                    var header = new BacklogColumnHeader(title);

                    _table.ColumnHeaders.Add(header);
                }
            }

            private void ReadRows()
            {
                var rowStartIndex = _tableRange.RowStartIndex;

                if (_hasHeaders)
                    rowStartIndex += 1;

                for (int rowIndex = rowStartIndex; rowIndex <= _tableRange.RowEndIndex; rowIndex++)
                {
                    var row = ReadRow(rowIndex);

                    _table.Rows.Add(row);
                }
            }

            private BacklogItemRow ReadRow(int rowIndex)
            {
                var row = new BacklogItemRow();

                for (int columnIndex = _tableRange.ColumnStartIndex; columnIndex <= _tableRange.ColumnEndIndex; columnIndex++)
                {
                    row.Add(_worksheet.Cells[rowIndex, columnIndex].Value);
                }

                return row;
            }     
        }
    }
}
namespace Gosu.Backlog.Models
{
    public class ExcelSheetUploadModel
    {
        public ExcelSheetUploadModel()
        {
            WorksheetIndex = 1;
            HasHeaders = true;
        }

        public bool HasHeaders { get; set; }
        public int WorksheetIndex { get; set; }
    }
}
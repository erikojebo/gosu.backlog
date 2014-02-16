using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gosu.Backlog.Models;
using Gosu.Backlog.Models.Excel;
using OfficeOpenXml;

namespace Gosu.Backlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new ExcelSheetUploadModel());
        }
        
        [HttpPost]
        public ActionResult Upload(ExcelSheetUploadModel model)
        {
            ValidateWorkbook();

            if (!ModelState.IsValid)
            {
                return ValidationError("Index", model);
            }

            using (var package = new ExcelPackage(Request.Files[0].InputStream))
            {
                ValidateWorksheetIndex(model, package);

                if (!ModelState.IsValid)
                {
                    return ValidationError("Index", model);
                }

                var worksheet = package.Workbook.Worksheets[model.WorksheetIndex];

                var table = BacklogTable.Read(worksheet, model.HasHeaders);

                return View("CardSetup", table);
            }
        }

        public ActionResult Layout()
        {
            return View();
        }

        private void ValidateWorkbook()
        {
            if (Request.Files.Count <= 0 || Request.Files[0] == null)
                ModelState.AddModelError("backlogFile", "No file was uploaded");
        }

        private void ValidateWorksheetIndex(ExcelSheetUploadModel model, ExcelPackage package)
        {
             var isWorksheetIndexValid = model.WorksheetIndex >= 1 && model.WorksheetIndex <= package.Workbook.Worksheets.Count;

            if (!isWorksheetIndexValid)
                ModelState.AddModelError("WorksheetIndex", "Invalid worksheet index");
        }

        private ActionResult Error(string message)
        {
            return View("Error", new ErrorModel(message));
        }

        private ActionResult ValidationError(string viewName, object model)
        {
            Response.AddHeader("isValid", "false");

            if (string.IsNullOrWhiteSpace(viewName))
                return View(model);

            return View(viewName, model);
        }
    }
}
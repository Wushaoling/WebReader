using System;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebReader.Factory
{
    public class ExcelUtil : CanvertUtil
    {
        public override bool CanvertFormat(string fullfilename)
        {
            if (!Path.GetExtension(fullfilename).Equals(".xls") && !Path.GetExtension(fullfilename).Equals(".xlsx"))
                return false;
            string sour = sourcepath + "\\" + fullfilename;
            string dest = sourcepath + "\\" + Path.GetFileNameWithoutExtension(fullfilename) + ".pdf";
            if (!XLSConvertToPDF(sour, dest))
                return false;
            if (!PDFConvertToSWF(Path.GetFileNameWithoutExtension(fullfilename) + ".pdf"))
                return false;
            if (File.Exists(sourcepath + "\\" + Path.GetFileNameWithoutExtension(fullfilename) + ".pdf"))
                File.Delete(sourcepath + "\\" + Path.GetFileNameWithoutExtension(fullfilename) + ".pdf");
            return true;
        }

        public bool XLSConvertToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Excel.XlFixedFormatType targetType = Excel.XlFixedFormatType.xlTypePDF;
            object missing = Type.Missing;
            Excel.Application application = null;
            Excel.Workbook workBook = null;
            try
            {
                application = new Excel.Application();
                object target = targetPath;
                object type = targetType;
                workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing, missing);

                workBook.ExportAsFixedFormat(targetType, target, Excel.XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return result;
        }
    }
}
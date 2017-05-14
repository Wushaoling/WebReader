using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebReader.Factory
{
    public class PPTUtil : CanvertUtil
    {
        public override bool CanvertFormat(string fullfilename)
        {
            //if (!System.IO.Path.GetExtension(fullfilename).Equals(".ppt") && !System.IO.Path.GetExtension(fullfilename).Equals(".pptx"))
            //    return false;
            //string sour = sourcepath + "\\" + fullfilename;
            //string dest = sourcepath + "\\" + System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf";
            //if (!PPTConvertToPDF(sour, dest))
            //    return false;
            //if (!PDFConvertToSWF(System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf"))
            //    return false;
            //if (File.Exists(sourcepath + "\\" + System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf"))
            //    File.Delete(sourcepath + "\\" + System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf");
            return true;
        }
        //public bool PPTConvertToPDF(string sourcePath, string targetPath)
        //{
        //    bool result;
        //    PowerPoint.PpSaveAsFileType targetFileType = PowerPoint.PpSaveAsFileType.ppSaveAsPDF;
        //    object missing = Type.Missing;
        //    PowerPoint.Application application = null;
        //    PowerPoint.Presentation persentation = null;
        //    try
        //    {
        //        application = new PowerPoint.Application();
        //        persentation = application.Presentations.Open(sourcePath, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse);
        //        persentation.SaveAs(targetPath, targetFileType, Microsoft.Office.Core.MsoTriState.msoTrue);

        //        result = true;
        //    }
        //    catch
        //    {
        //        result = false;
        //    }
        //    finally
        //    {
        //        if (persentation != null)
        //        {
        //            persentation.Close();
        //            persentation = null;
        //        }
        //        if (application != null)
        //        {
        //            application.Quit();
        //            application = null;
        //        }
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //    return result;
        //}
    }
}
using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace WebReader.Factory
{
    public class WordUtil : CanvertUtil
    {
        public override bool CanvertFormat(string fullfilename)
        {
            if (!System.IO.Path.GetExtension(fullfilename).Equals(".doc") && !System.IO.Path.GetExtension(fullfilename).Equals(".docx"))
                return false;
            string sour = sourcepath + "\\" + fullfilename;
            string dest = sourcepath + "\\" + System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf";
            if (!DOCConvertToPDF(sour, dest))
                return false;
            if (!PDFConvertToSWF(System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf"))
                return false;
            if (File.Exists(sourcepath + "\\" + System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf"))
                File.Delete(sourcepath + "\\" + System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".pdf");
            return true;
        }

        public bool DOCConvertToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Word.WdExportFormat exportFormat = Word.WdExportFormat.wdExportFormatPDF;
            object paramMissing = Type.Missing;
            Word.Application wordApplication = new Word.Application();
            Word.Document wordDocument = null;
            try
            {
                object paramSourceDocPath = sourcePath;
                string paramExportFilePath = targetPath;

                Word.WdExportFormat paramExportFormat = exportFormat;
                bool paramOpenAfterExport = false;
                Word.WdExportOptimizeFor paramExportOptimizeFor = Word.WdExportOptimizeFor.wdExportOptimizeForPrint;
                Word.WdExportRange paramExportRange = Word.WdExportRange.wdExportAllDocument;
                int paramStartPage = 0;
                int paramEndPage = 0;
                Word.WdExportItem paramExportItem = Word.WdExportItem.wdExportDocumentContent;
                bool paramIncludeDocProps = true;
                bool paramKeepIRM = true;
                Word.WdExportCreateBookmarks paramCreateBookmarks = Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                bool paramDocStructureTags = true;
                bool paramBitmapMissingFonts = true;
                bool paramUseISO19005_1 = false;

                wordDocument = wordApplication.Documents.Open(
                ref paramSourceDocPath, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing, ref paramMissing, ref paramMissing,
                ref paramMissing);

                if (wordDocument != null)
                    wordDocument.ExportAsFixedFormat(paramExportFilePath,
                    paramExportFormat, paramOpenAfterExport,
                    paramExportOptimizeFor, paramExportRange, paramStartPage,
                    paramEndPage, paramExportItem, paramIncludeDocProps,
                    paramKeepIRM, paramCreateBookmarks, paramDocStructureTags,
                    paramBitmapMissingFonts, paramUseISO19005_1,
                    ref paramMissing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (wordDocument != null)
                {
                    wordDocument.Close(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordDocument = null;
                }
                if (wordApplication != null)
                {
                    wordApplication.Quit(ref paramMissing, ref paramMissing, ref paramMissing);
                    wordApplication = null;
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
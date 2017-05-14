using System;
using System.Diagnostics;
using System.IO;
using System.Web;

namespace WebReader.Factory
{
    public abstract class CanvertUtil
    {

        //注意所有路路径均不能出现空格，包括工程的路径
        protected string pdf2swftoolpath = HttpContext.Current.Server.MapPath("~/lib/pdf2swf.exe");
        protected string savepath = HttpContext.Current.Server.MapPath("~/dataout");//保存路径
        protected string sourcepath = HttpContext.Current.Server.MapPath("~/data");//源文件路径

        //转换格式
        public abstract bool CanvertFormat(string fullfilename);

        //将pdf转为swf
        public bool PDFConvertToSWF(string fullfilename)
        {
            if (!File.Exists(sourcepath + "\\" + fullfilename))
                return false;
            if (!System.IO.Path.GetExtension(fullfilename).Equals(".pdf"))
                return false;
            string args = " -t " + sourcepath + "\\" + fullfilename + " -o " + savepath + "\\" + System.IO.Path.GetFileNameWithoutExtension(fullfilename) + ".swf";
            Process pc = new Process();
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(pdf2swftoolpath, args);
                psi.WindowStyle = ProcessWindowStyle.Hidden;
                pc.StartInfo = psi;
                pc.Start();
                pc.WaitForExit();
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(ex.Message);
            }
            finally
            {
                pc.Close();
                pc.Dispose();
            }
            return true;
        }
    }
}
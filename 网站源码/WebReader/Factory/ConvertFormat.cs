using System;
using System.IO;

namespace WebReader.Factory
{
    public class CanvertFormat
    {
        public String Execute(String filename)
        {
            String extension = Path.GetExtension(filename).ToLower();
            switch (extension)
            {
                case ".pdf":
                    return new PDFUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".xls":
                    return new ExcelUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".xlsx":
                    return new ExcelUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".doc":
                    return new WordUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".docx":
                    return new WordUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case "ppt":
                    return "需在源码中重新配置引用";//return new PPTUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case "pptx":
                    return "需在源码中重新配置引用";//return new PPTUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".jpg":
                    return new PicUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".jpeg":
                    return new PicUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".bmp":
                    return new PicUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                case ".gif":
                    return new PicUtilFactory().CreateCanvertUtil().CanvertFormat(filename) ? null : "格式转换失败";
                default:
                    return "格式不支持";
            }
        }
    }
}
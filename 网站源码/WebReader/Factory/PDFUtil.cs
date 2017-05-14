namespace WebReader.Factory
{
    public class PDFUtil : CanvertUtil
    {
        public override bool CanvertFormat(string fullfilename)
        {
            return PDFConvertToSWF(fullfilename);
        }
    }
}
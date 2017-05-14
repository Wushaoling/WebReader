namespace WebReader.Factory
{
    public class PDFUtilFactory : CanvertUtilFactory
    {
        public CanvertUtil CreateCanvertUtil()
        {
            return new PDFUtil();
        }
    }
}
namespace WebReader.Factory
{
    public class ExcelUtilFactory : CanvertUtilFactory
    {
        public CanvertUtil CreateCanvertUtil()
        {
            return new ExcelUtil();
        }
    }
}
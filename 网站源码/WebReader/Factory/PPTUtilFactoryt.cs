using System;

namespace WebReader.Factory
{
    public class PPTUtilFactory : CanvertUtilFactory
    {
        public CanvertUtil CreateCanvertUtil()
        {
            return new PPTUtil();
        }
    }
}
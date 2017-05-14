using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebReader.Factory
{
    public class PicUtilFactory : CanvertUtilFactory
    {
        public CanvertUtil CreateCanvertUtil()
        {
            return new PicUtil();
        }
    }
}
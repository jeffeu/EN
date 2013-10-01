using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnlaceNoivas.Helpers
{
    public class TagHelper
    {
        public static bool isEmpity(String tag)
        {
            if (tag.IndexOf("><") == -1)
                return false;
            else
                return true;
        }
    }
}
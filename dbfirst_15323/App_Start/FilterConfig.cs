﻿using System.Web;
using System.Web.Mvc;

namespace dbfirst_15323
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

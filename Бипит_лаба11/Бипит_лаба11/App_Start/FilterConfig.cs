﻿using System.Web;
using System.Web.Mvc;

namespace Бипит_лаба11
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

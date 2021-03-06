﻿using System.Web;
using System.Web.Mvc;
using Seminarski.Models;

namespace Seminarski
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute() { Roles = RoleName.Zaposlenik });
        }
    }
}

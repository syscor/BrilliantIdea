﻿using System.Web.Http.Filters;
using System.Web.Mvc;
using BrilliantIdea.WebAPI.Filters;

namespace BrilliantIdea.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterHttpFilters(HttpFilterCollection filters)
        {
            filters.Add(new ModelValidationFilterAttribute());
        }
    }
}
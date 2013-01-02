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
    }
}
using System.Web.Http;
using BrilliantIdea.Framework.DAL;
using BrilliantIdea.WebAPI.Filters;
using Ninject;


namespace BrilliantIdea.WebAPI.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

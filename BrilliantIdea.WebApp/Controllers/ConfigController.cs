using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;

namespace BrilliantIdea.WebApp.Controllers
{
    public class ConfigController : Controller
    {
        public ActionResult ControlPanel()
        {
            return PartialView();
        }

        public ActionResult BoardSettings()
        {
            return PartialView();
        }

        public JsonResult Getboards()
        {
            var client = new RestClient("http://localhost:3916");
            var request = new RestRequest("/api/config/getboards", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);
            return Json("success", JsonRequestBehavior.AllowGet);


        }

        public JsonResult Getboards2()
        {
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrilliantIdea.WebApp.Models.DTOs;
using BrilliantIdea.WebApp.Models.ViewModel;
using RestSharp;
using System.Net;
using System.Configuration;

namespace BrilliantIdea.WebApp.Controllers
{
    public class SensorController : SysCorControllerBase
    {
        public ActionResult SensorPanel()
        {
            return PartialView();
        }

        public JsonResult GetSensors(int type)
        {
            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("api/sensor/getsensors/" + type, Method.GET);
            var response = client.Execute<SensorListDTO>(request);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public class SensorListDTO : List<SensorDTO>
        {
             
        }
    }
}

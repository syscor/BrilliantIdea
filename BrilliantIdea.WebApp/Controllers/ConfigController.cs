using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrilliantIdea.WebApp.Models.DTOs;
using BrilliantIdea.WebApp.Models.ViewModel;
using Newtonsoft.Json;
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

        public JsonResult GetBoards()
        {
            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("/api/config/getboards", Method.GET);
            var response = client.Execute<BoardTypeDTO>(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

       
        public class BoardTypeDTO : List<BoardTypeModelDTO>{}
    }
}

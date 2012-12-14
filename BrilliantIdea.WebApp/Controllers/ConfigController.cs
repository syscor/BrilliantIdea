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
    public class ConfigController : SysCorControllerBase
    {
        public ActionResult ControlPanel()
        {
            return PartialView();
        }

        public ActionResult BoardSettings()
        {
            return PartialView();
        }

        public JsonResult GetBoardTypes()
        {
            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("/api/config/gettypeboards", Method.GET);
            var response = client.Execute<BoardTypeDTO>(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

       public JsonResult TestCommunication(string url)
       {
           try
           {

           }
           catch (Exception)
           {
               
               throw;
           }
           return Json("success", JsonRequestBehavior.AllowGet);
       }

        public class BoardTypeDTO : List<BoardTypeModelDTO>{}
    }
}

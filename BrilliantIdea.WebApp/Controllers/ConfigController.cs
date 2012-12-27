﻿using System.Collections.Generic;
using System.Web.Mvc;
using BrilliantIdea.WebApp.Models.DTOs;
using BrilliantIdea.WebApp.Models.ViewModel;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Validation;

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

        public ActionResult RestoreSettings()
        {
            return PartialView();
        }

        public JsonResult InitializeConfigs()
        {
            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("/api/config/getinitializeboards", Method.GET);
            var response = client.Execute(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBoardTypes()
        {
            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("/api/config/gettypeboards", Method.GET);
            var response = client.Execute<BoardTypeDTO>(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBoards()
        {
            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("api/config/getboards", Method.GET);
            var response = client.Execute<BoardDeviceListDTO>(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveBoardDevice(string boardJson)
        {
            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("api/config/SaveBoardDevice", Method.POST);
            request.AddBody(boardJson);

            var response = client.Execute(request);

            var device2 = JObject.Parse(boardJson);
            return Json("success");
        }

        public JsonResult TestCommunication(string url)
        {
            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public class BoardTypeDTO
        {
            public List<BoardTypeModelDTO> BoardTypeList { get; set; }
        }

        public class BoardDeviceListDTO : List<BoardDeviceDTO>
        {
        }
    }

}

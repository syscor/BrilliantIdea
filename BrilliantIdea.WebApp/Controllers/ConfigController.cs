using System;
using System.Collections.Generic;
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
            var boardDevice = JsonConvert.DeserializeObject<BoardDeviceDTO>(boardJson);
            boardDevice.DeviceId = Guid.NewGuid();
            boardDevice.LastUpdate = DateTime.Now;

            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("api/config/postboard", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json",JsonConvert.SerializeObject(boardDevice), ParameterType.RequestBody);
            var response = client.Execute(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult UpdateBoardDevice(string boardJson)
        {
            var boardDevice = JsonConvert.DeserializeObject<BoardDeviceDTO>(boardJson);
            boardDevice.LastUpdate = DateTime.Now;

            var client = new BrilliantIdeaApi("", "");
            var request = new RestRequest("api/config/postboard", Method.POST);
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(boardDevice), ParameterType.RequestBody);
            var response = client.Execute(request);
            return Json(response);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BrilliantIdea.Framework.Boards;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace BrilliantIdea.WebAPI.Controllers
{
    public class ConfigController : ApiController
    {

        /// <summary>
        /// Get all devices
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BoardDevice> GetBoards()
        {
            var boards = new Boards();
            var result = new List<BoardDevice>();
            return result;
        }


        /// <summary>
        /// Get all type boards
        /// </summary>
        /// <returns>List of objetcs BoardTypeModel</returns>
        public IEnumerable<BoardTypeModel> GetTypeBoards()
        {
            var boards = new Boards();
            var result = boards.GetAllBoardTypes();
            return result;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
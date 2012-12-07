using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BrilliantIdea.Framework.Utils;

namespace BrilliantIdea.WebAPI.Controllers
{
    public class ConfigController : ApiController
    {
        // GET api/config
        public JsonResult Get()
        {
            var dbInitialize = new DBInitialization();
            dbInitialize.Initialize();
            return "success";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}

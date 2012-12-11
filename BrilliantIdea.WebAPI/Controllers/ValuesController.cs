using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrilliantIdea.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            //const string connectionstring = @"metadata=res://*/Model.SysCorModel.csdl|res://*/Model.SysCorModel.ssdl|res://*/Model.SysCorModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(local)\SQLEXPRESS;initial catalog=SysCor;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            //Domain.Temperature.TemperatureDomain.SetConnectionString(connectionstring);
            return new string[] { "value1", "value2" };
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
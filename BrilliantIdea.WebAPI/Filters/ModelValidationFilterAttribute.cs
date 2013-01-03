using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;

namespace BrilliantIdea.WebAPI.Filters
{
    public class ModelValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var errors = new Dictionary<string, IEnumerable<string>>();
                foreach (var keyValuePair in actionContext.ModelState)
                {
                    errors[keyValuePair.Key] = keyValuePair.Value.Errors.Select(e => e.ErrorMessage);
                }

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
    }
}
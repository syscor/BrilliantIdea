using System.Net;
using System.Web.Http.Filters;
using System.Net.Http;

namespace BrilliantIdea.WebAPI.Filters
{
    public class ValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var modelState = actionExecutedContext.ActionContext.ModelState;
            if (!modelState.IsValid)
            {
                actionExecutedContext.Response =
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    }
}
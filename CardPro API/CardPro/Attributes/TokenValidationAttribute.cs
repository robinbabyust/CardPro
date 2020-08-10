using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Threading.Tasks;

namespace CardPro.Attributes
{
    public class TokenValidationAttribute : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            HttpRequest request = context.HttpContext.Request;
            bool isValidRequest = false;

            if (request.Headers != null && request.Headers.ContainsKey("Token"))
            {
                if (request.Headers["Token"] == "CarPro Validation Token")
                {
                    isValidRequest = true;
                }
            }

            if(!isValidRequest)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
            }
            else
            {
                await next();
            }
        }
    }
}

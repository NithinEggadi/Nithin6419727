using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_3.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var hasHeader = context.HttpContext.Request.Headers.TryGetValue("key", out var keyValue);

            if (!hasHeader || keyValue != "admin")
            {
                context.Result = new UnauthorizedResult(); // 401 Unauthorized
            }
        }
    }
}
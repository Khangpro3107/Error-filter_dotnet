using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.Filters
{
    // authorization filter
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine($"OnAuthorization {context.HttpContext.Request.Path}");
        }
    }
}

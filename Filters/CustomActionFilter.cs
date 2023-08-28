using Microsoft.AspNetCore.Mvc.Filters;

namespace DI.Filters
{
    // action filter
    public class CustomActionFilter: IActionFilter
    {
        public CustomActionFilter() { }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"OnActionExecuting {context.HttpContext.Request.Path}");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"OnActionExecuted {context.HttpContext.Request.Path}");
        }
    }
}

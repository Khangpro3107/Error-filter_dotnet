using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.Filters
{
    // resource filter
    public class CustomResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"OnResourceExecuted {context.HttpContext.Request.Path}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"OnResourceExecuting {context.HttpContext.Request.Path}");
        }
    }
}

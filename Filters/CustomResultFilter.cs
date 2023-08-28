using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.Filters
{
    // result filter, will not run if exception filter runs
    public class CustomResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"OnResultExecuted {context.HttpContext.Request.Path}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"OnResultExecuting {context.HttpContext.Request.Path}");
        }
    }
}

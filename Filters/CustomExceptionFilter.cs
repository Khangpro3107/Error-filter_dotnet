using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.Filters
{
    // exception filter
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // this shows how to get access to the thrown exception
            Console.WriteLine($"OnException {context.HttpContext.Request.Path}: {context.Exception.Message}");
            context.Result = new ContentResult { Content = $"The error '{context.Exception.Message}' is handled by the filter." };
        }
    }
}

using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.Filters
{
    // an async filter
    public class AsyncFilterAttribute : Attribute, IAsyncActionFilter
    {
        // async filters only need one method, as opposed to sync ones' two
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)      // context and next are similar, but not the same as in middlewares
        {
            await Console.Out.WriteLineAsync("Before next");
            // 'next' calls the 'Action' chosen by a controller; this action is wrapped between line 11 and 14
            await next();
            await Console.Out.WriteLineAsync("After next");
        }
    }
}

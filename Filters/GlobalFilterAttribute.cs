using Microsoft.AspNetCore.Mvc.Filters;

namespace ErrorHandling.Filters
{
    // a filter that can be used like an attribute
    public class GlobalFilterAttribute : Attribute, IResourceFilter, IOrderedFilter
    {
        public string message { get; set; }

        public int Order { get; set; }

        public GlobalFilterAttribute(string message = "Global", int order = 0)
        {
            this.message = message;
            Order = order;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"GlobalFilterAttribute OnResourceExecuted: {message} {Order}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"GlobalFilterAttribute OnResourceExecuting: {message} {Order}");
        }
    }
}

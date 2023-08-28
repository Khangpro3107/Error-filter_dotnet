namespace ErrorHandling.Middlewares
{
    public class MyExceptionHandlingMiddleware: IMiddleware
    {
        public MyExceptionHandlingMiddleware()
        {
            
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                // calling other middlewares to see if any error happens...
                await next(context);
            }
            // catching those errors...
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Handled in middleware: {ex.Message}");
                await context.Response.WriteAsync("Exception Middleware " + ex.Message);
            }
        }
    }
}

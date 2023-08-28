using ErrorHandling.Services;

namespace ErrorHandling.Middlewares
{
    public class CustomMiddleware: IMiddleware
    {
        public LogService _logService { get; set; }
        public ILogger logger { get; set; }
        public CustomMiddleware(LogService logService, ILogger logger)
        {
            this._logService = logService;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            this._logService.Write("InvokeAsync");
            await next(context);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ErrorHandling.Pages
{
    public class CustomExceptionModel : PageModel
    {
        private readonly ILogger<CustomExceptionModel> _logger;

        public CustomExceptionModel(ILogger<CustomExceptionModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
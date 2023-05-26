using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class OrderSuccessfulModel : PageModel
    {
        private readonly ILogger<OrderSuccessfulModel> _logger;
        public OrderSuccessfulModel(ILogger<OrderSuccessfulModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}

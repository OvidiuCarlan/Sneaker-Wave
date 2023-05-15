using Logic.DTOs;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class PaymentModel : PageModel
    {
        [BindProperty]
        public CardDTO card { get; private set; }
        public void OnGet()
        {
        }
    }
}

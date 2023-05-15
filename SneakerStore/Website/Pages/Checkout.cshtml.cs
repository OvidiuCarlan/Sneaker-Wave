using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public AddressDTO address { get; private set; } 

        private readonly ILogger<IndexModel> _logger;
        public CheckoutModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                StoreAddress(address);
            }
            return RedirectToPage("Payment");
        }
        public void StoreAddress(AddressDTO address)
        {
            string json = JsonSerializer.Serialize(address);
            HttpContext.Session.SetString("address", json);
        }
    }
}

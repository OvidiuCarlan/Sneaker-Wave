using Logic.DTOs;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class PersonalDataModel : PageModel
    {
        [BindProperty]
        public CustomerDTO customer { get; set; }
        public string errorMessage { get; set; }
        private readonly ILogger<PersonalDataModel> _logger;
        public PersonalDataModel(ILogger<PersonalDataModel> logger)
        {
            _logger = logger;
        }
        public IActionResult OnGet()
        {
            List<ShoppingCartItemDTO> cartItems = GetCartItems();
            if(cartItems.Count == 0 || (User?.Identity?.IsAuthenticated ?? false))
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserDataValidation.RegisterValidation(customer);
                    StorePersonalData(customer);
                    return RedirectToPage("Checkout");
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                    return Page();
                }
            }
            return Page();
        }
        public void StorePersonalData(CustomerDTO customer)
        {
            string json = JsonSerializer.Serialize(customer);
            HttpContext.Session.SetString("userData", json);
        }
        public List<ShoppingCartItemDTO> GetCartItems()
        {
            string json = HttpContext.Session.GetString("CartItems");

            if (string.IsNullOrEmpty(json))
            {
                // If the session value for "CartItems" is null or empty, return an empty list
                return new List<ShoppingCartItemDTO>();
            }
            else
            {
                // Deserialize the JSON into a list of ShoppingCartItems
                List<ShoppingCartItemDTO> cartItems = JsonSerializer.Deserialize<List<ShoppingCartItemDTO>>(json);
                return cartItems;
            }
        }
    }
}
 
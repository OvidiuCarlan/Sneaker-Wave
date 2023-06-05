using Logic.DTOs;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class CheckoutModel : PageModel
    {
        [BindProperty]
        public AddressDTO address { get; set; }

        private readonly ILogger<IndexModel> _logger;
        public CheckoutModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {

            List<ShoppingCartItemDTO> cartItems = GetCartItems();

            if (!IsUserDataValid() || cartItems.Count == 0)
            {
                return RedirectToPage("Index");
            }
            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                StoreAddress(address);
                return RedirectToPage("Payment");
            }
            return Page();
        }
        /// <summary>
        /// This method stores user address in a session
        /// </summary>
        /// <param name="address"></param>
        public void StoreAddress(AddressDTO address)
        {
            string json = JsonSerializer.Serialize(address);
            HttpContext.Session.SetString("address", json);
        }

        /// <summary>
        /// This method gets user data from a session
        /// </summary>
        /// <returns>Object of type Customer containing user data</returns>
        /// <exception cref="Exception"></exception>
        public Customer GetUserData()
        {
            CustomerDTO customerDto = new CustomerDTO();
            Customer customer;

            string json = HttpContext.Session.GetString("userData");

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            else
            {
                customerDto = JsonSerializer.Deserialize<CustomerDTO>(json);
                customer = new Customer(customerDto);
            }
            return customer;
        }
        /// <summary>
        /// This method checks if the user data is valid
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Returns true or false depending if the usre data is valid or not</returns>
        public bool IsUserDataValid()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return true;
            }
            else
            {
                Customer customer = GetUserData();

                if (customer == null ||
               string.IsNullOrEmpty(customer.FirstName) ||
               string.IsNullOrEmpty(customer.LastName) ||
               string.IsNullOrEmpty(customer.Email) ||
               string.IsNullOrEmpty(customer.Phone))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// This method gets a list of all the items that are in the shopping cart.
        /// </summary>
        /// <returns>Shopping cart items list</returns>
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

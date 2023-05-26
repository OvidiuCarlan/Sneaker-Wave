using Logic.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public List<ShoppingCartItemDTO> cartItems { get; set; }
        public double Total { get; set; }
        public void OnGet()
        {
            cartItems = GetCartItems();
            Total = CalculateTotalPrice();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                StoreTotalPrice(Total);
                return RedirectToPage("Checkout");
            }
            return Page();
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
        /// <summary>
        /// Calculates the total price of the shopping cart without discounts
        /// </summary>
        /// <returns>Total price of the shopping cart</returns>
        public double CalculateTotalPrice()
        {
            double total = 0;

            foreach (ShoppingCartItemDTO item in cartItems)
            {
                double subtotal = item.Quantity * item.Product.Price;
                total += subtotal;
            }
            return total;
        }
        /// <summary>
        /// Stores the price of the shopping cart
        /// </summary>
        /// <param name="price">The total price of the shopping cart</param>
        public void StoreTotalPrice(double price)
        {
            string json = JsonSerializer.Serialize(price);
            HttpContext.Session.SetString("Price", json);
        }
    }
}

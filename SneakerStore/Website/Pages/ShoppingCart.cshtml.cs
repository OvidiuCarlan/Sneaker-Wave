using Logic.DTOs;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public List<ShoppingCartItemDTO> cartItems { get; set; }
        public void OnGet()
        {
            cartItems = GetCartItems();
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

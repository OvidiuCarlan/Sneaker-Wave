using DAL.DBs;
using DAL.DTOs;
using Logic.DTOs;
using Logic.Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class ProductInfoModel : PageModel
    {
        ProductManager productManager = new ProductManager(new ProductDataHandler());
        [BindProperty]
        public ProductDTO productDto { get; set; }
        [BindProperty]
        public List<string> sizes { get; set; }
        public List<ShoppingCartItem> shoppingCart = new List<ShoppingCartItem>();
        private int productId { get; set; }

        public void OnGet(int id)
        {
            productDto = productManager.GetProductById(id);
            GetSizes(id);
        }

        /// <summary>
        /// Gets all the sizes available for a specific product
        /// </summary>
        public void GetSizes(int id)
        {
            sizes = productManager.GetSizesById(id);
        }

        public async Task<IActionResult> OnPost(string productSize, int productQuantity, int id)
        {
            productDto = productManager.GetProductById(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }
            ShoppingCartItemDTO item = new ShoppingCartItemDTO();
            item.Product = productDto;
            item.Size = productSize;
            item.Quantity = productQuantity;

            AddToShoppingCart(item);

            return RedirectToPage("ShoppingCart");
        }

        
        /// <summary>
        /// This method adds a item to the shopping cart session. It first checks if the item is already in the shopping
        /// cart and if so it just increases the quantity, otherwise it adds it to the shopping cart. 
        /// </summary>
        /// <param name="item">Item that needs to be added to the shopping cart</param>
        public void AddToShoppingCart(ShoppingCartItemDTO item)
        {
            List<ShoppingCartItemDTO> cartItems = GetCartItems();

            if(cartItems.Count == 0)
            {
                cartItems.Add(item);
            }
            else
            { 
                bool quantityUpdated = false;
                foreach (ShoppingCartItemDTO itemInCart in cartItems)
                {
                    if (item.Product.Id == itemInCart.Product.Id && item.Size == itemInCart.Size)
                    {
                        itemInCart.Quantity += item.Quantity;
                        quantityUpdated = true;
                    }
                }
                if(!quantityUpdated)
                {
                    cartItems.Add(item);
                }
            }

            string json = JsonSerializer.Serialize(cartItems);
            HttpContext.Session.SetString("CartItems", json);
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

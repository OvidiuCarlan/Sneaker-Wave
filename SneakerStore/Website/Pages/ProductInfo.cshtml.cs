using DAL.DBs;
using Logic.Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class ProductInfoModel : PageModel
    {
        private int productId { get; set; }
        ProductManager productManager = new ProductManager(new ProductDataHandler());
        [BindProperty]
        public Product product { get; set; }
        [BindProperty]
        public List<string> sizes { get; set; }
        public List<ShoppingCartItem> shoppingCart = new List<ShoppingCartItem>();

        public void OnGet(int id)
        {
            product = productManager.GetProductById(id);
            GetSizes();
        }

        /// <summary>
        /// Gets all the sizes available for a specific product
        /// </summary>
        public void GetSizes()
        {
            sizes = productManager.GetSizesById(product.Id);
        }


        public async Task<IActionResult> OnPost(int productId, string productName, string productSize, float productPrice, int productQuantity)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ShoppingCartItem item = new ShoppingCartItem(productId, productName, productSize, productPrice, productQuantity);

            AddToShoppingCart(item);

            return Page();
        }

        
        /// <summary>
        /// This method adds a item to the shopping cart session. It first checks if the item is already in shoppin cart and if so it
        /// just increases the quantity, otherwise it adds it to the shopping cart. 
        /// </summary>
        /// <param name="item">Item that needs to be added to the shopping cart</param>
        public void AddToShoppingCart(ShoppingCartItem item)
        {
            List<ShoppingCartItem> cartItems = GetCartItems();

            if(cartItems.Count == 0)
            {
                cartItems.Add(item);
            }
            else
            {
                foreach (ShoppingCartItem itemInCart in cartItems)
                {
                    if (item.ProductId == itemInCart.ProductId)
                    {
                        itemInCart.Quantity += item.Quantity;
                    }
                    else
                    {
                        cartItems.Add(item);
                    }
                }
            }           

            string json = JsonSerializer.Serialize(cartItems);
            HttpContext.Session.SetString("CartItems", json);
        }
        /// <summary>
        /// This method gets a list of all the items that are in the shopping cart.
        /// </summary>
        /// <returns>Shopping cart items list</returns>
        public List<ShoppingCartItem> GetCartItems()
        {
            string json = HttpContext.Session.GetString("CartItems");

            if (string.IsNullOrEmpty(json))
            {
                // If the session value for "CartItems" is null or empty, return an empty list
                return new List<ShoppingCartItem>();
            }
            else
            {
                // Deserialize the JSON into a list of ShoppingCartItems
                List<ShoppingCartItem> cartItems = JsonSerializer.Deserialize<List<ShoppingCartItem>>(json);
                return cartItems;
            }
        }














        public T GetObjectFromJson<T>(ISession session, string key)
        {
            var jsonString = session.GetString(key);
            if (jsonString == null)
            {
                return default(T);
            }
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}

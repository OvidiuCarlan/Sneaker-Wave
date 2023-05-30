using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text.Json;

namespace Website.Pages
{
    public class PaymentModel : PageModel
    {
        [BindProperty]
        public CardDTO cardDTO { get; set; }
        private Customer customer { get; set; }
        public DateTime dateTime;
        private Address address { get; set; }
        List<ShoppingCartItem> items { get; set; } 
        double totalPrice { get; set; }
        Order order { get; set; }
        private Card card { get; set; }
        string errorMessage { get; set; }

        private readonly ILogger<PaymentModel> _logger;
        private readonly IOrderManager orderManager;
        private readonly IBonusCardManager bonusCardManager;
        public PaymentModel(ILogger<PaymentModel> logger, IOrderManager _orderManager, IBonusCardManager _bonusCardManager)
        {
            orderManager = _orderManager;
            bonusCardManager = _bonusCardManager;
            _logger = logger;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {               
                customer = GetCurrentUser();
                dateTime = DateTime.Now;
                address = GetAddress();
                items = GetCartItems();
                totalPrice = GetTotalPrice();
                card = new Card(cardDTO);
                string status = "Open";

                order = new Order(customer, dateTime, address, items, card, totalPrice, status);
                try
                {
                    orderManager.AddAccountOrder(order);
                    bonusCardManager.SaveBonusPoints(totalPrice, customer.Id);
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    return Page();
                }                
            }
            return RedirectToPage("OrderCompleted");
        }


        /// <summary>
        /// Retrieves the current user details needed for the order.
        /// </summary>
        /// <returns>Current user details</returns>
        public Customer GetCurrentUser()
        {
            CustomerDTO currentUserDTO = new CustomerDTO();

            currentUserDTO.Id = Convert.ToInt32(User?.FindFirst("id")?.Value ?? string.Empty);
            currentUserDTO.firstName = User?.FindFirst("firstName")?.Value ?? string.Empty;
            currentUserDTO.lastName = User?.FindFirst("lastName")?.Value ?? string.Empty;
            currentUserDTO.email = User?.FindFirst("email")?.Value ?? string.Empty;
            currentUserDTO.phone = User?.FindFirst("phone")?.Value ?? string.Empty;

            Customer currentUser = new Customer(currentUserDTO);

            return currentUser;
        }
        /// <summary>
        /// Gets the user's address from the session
        /// </summary>
        /// <returns>Current user's address</returns>
        public Address GetAddress()
        {
            AddressDTO addressDTO = new AddressDTO();
            Address address;

            string json = HttpContext.Session.GetString("address");

            if (string.IsNullOrEmpty(json))
            {
                return address = new Address();
            }
            else
            {
                addressDTO = JsonSerializer.Deserialize<AddressDTO>(json);
                address = new Address(addressDTO);
            }            
            return address;
        }
        /// <summary>
        /// This method gets a list of all the items that are in the shopping cart.
        /// </summary>
        /// <returns>Shopping cart items list</returns>
        public List<ShoppingCartItem> GetCartItems()
        {
            List<ShoppingCartItem> cartItems = new List<ShoppingCartItem>();
            string json = HttpContext.Session.GetString("CartItems");

            if (string.IsNullOrEmpty(json))
            {
                // If the session value for "CartItems" is null or empty, return an empty list
                return cartItems;
            }
            else
            {
                // Deserialize the JSON into a list of ShoppingCartItems
                List<ShoppingCartItemDTO> cartItemsDTO = JsonSerializer.Deserialize<List<ShoppingCartItemDTO>>(json);

                foreach (ShoppingCartItemDTO itemDTO in cartItemsDTO)
                {
                    cartItems.Add(new ShoppingCartItem(itemDTO));
                }
                return cartItems;
            }
        }
        /// <summary>
        /// Gets the total price of the shopping cart from the session
        /// </summary>
        /// <returns>Total price of the cart</returns>
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            string json = HttpContext.Session.GetString("Price");
            if (string.IsNullOrEmpty(json))
            {
                return totalPrice;
            }
            else
            {
                totalPrice = JsonSerializer.Deserialize<double>(json);
                return totalPrice;
            }
        }
    }
}

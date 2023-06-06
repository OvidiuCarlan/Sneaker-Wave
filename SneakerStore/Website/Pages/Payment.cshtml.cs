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
        public bool isAuthenticated = false;

        private readonly ILogger<PaymentModel> _logger;
        private readonly IOrderManager orderManager;
        private readonly IBonusCardManager bonusCardManager;
        double discountPrice { get; set; }
        public PaymentModel(ILogger<PaymentModel> logger, IOrderManager _orderManager, IBonusCardManager _bonusCardManager)
        {
            orderManager = _orderManager;
            bonusCardManager = _bonusCardManager;
            _logger = logger;
        }
        public IActionResult OnGet()
        {
            Customer customer = GetUser();            
            List<ShoppingCartItem> cartItems = GetCartItems();
            Address address = GetAddress();

            if (!IsUserDataValid(customer) || cartItems.Count == 0 || !IsAddressValid(address))
            {
                return RedirectToPage("Index");
            }          
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                order = GetOrder();

                if (isAuthenticated)
                {                    
                    try
                    {
                        discountPrice = orderManager.CheckForDiscounts(order.Price, order.Customer.Id);
                        orderManager.AddAccountOrder(order, discountPrice);
                        ClearAllOrderData();
                        return RedirectToPage("OrderCompleted");
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return Page();
                    }
                }
                else
                {
                    try
                    {
                        discountPrice = orderManager.CheckForDiscounts(order.Price, order.Customer.Id);
                        orderManager.AddNoAccountOrder(order, discountPrice);
                        ClearAllOrderData();
                        return RedirectToPage("OrderCompleted");
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        return Page();
                    }
                }
            }
            return Page();
        }
        /// <summary>
        /// This method returns order information
        /// </summary>
        /// <returns>Order object containing order information</returns>
        public Order GetOrder()
        {
            customer = GetUser();
            dateTime = DateTime.Now;
            address = GetAddress();
            items = GetCartItems();
            totalPrice = GetTotalPrice();
            card = new Card(cardDTO);
            string status = "Open";

            Order order = new Order(customer, dateTime, address, items, card, totalPrice, status);
            return order;
        }        
        
        /// <summary>
        /// This method returns a Customer type object containing customer information whether they have an account or not
        /// </summary>
        /// <returns>Customer object containing customer information</returns>
        /// <exception cref="Exception"></exception>
        public Customer GetUser()
        {
            CustomerDTO customerDto = new CustomerDTO();
            Customer customer;

            if (User?.Identity?.IsAuthenticated ?? false)
            {
                isAuthenticated = true;

                customerDto.Id = Convert.ToInt32(User?.FindFirst("id")?.Value ?? string.Empty);
                customerDto.firstName = User?.FindFirst("firstName")?.Value ?? string.Empty;
                customerDto.lastName = User?.FindFirst("lastName")?.Value ?? string.Empty;
                customerDto.email = User?.FindFirst("email")?.Value ?? string.Empty;
                customerDto.phone = User?.FindFirst("phone")?.Value ?? string.Empty;

                customer = new Customer(customerDto);
            }
            else
            {
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
            }         
            return customer;
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
        /// <summary>
        /// This method checks if there is any user data in the Customer object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Returns true or false depending if the usre data is valid or not</returns>
        public bool IsUserDataValid(Customer customer)
        {
            if (customer == null ||
               string.IsNullOrEmpty(customer.FirstName) ||
               string.IsNullOrEmpty(customer.LastName) ||
               string.IsNullOrEmpty(customer.Email) ||
               string.IsNullOrEmpty(customer.Phone))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// This method checks if there is any data in the Address object
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Returns true or false depending if the data is valid or not</returns>
        public bool IsAddressValid(Address address)
        {
            if (address == null ||
               string.IsNullOrEmpty(address.City) ||
               string.IsNullOrEmpty(address.Sreet) ||
               string.IsNullOrEmpty(address.HouseNumber) ||
               string.IsNullOrEmpty(address.Zipcode))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// This methos clears the sessions of all order data
        /// </summary>
        public void ClearAllOrderData()
        {
            if(isAuthenticated == false)
            {
                HttpContext.Session.Remove("userData");
            }
            HttpContext.Session.Remove("address");
            HttpContext.Session.Remove("Price");
            HttpContext.Session.Remove("CartItems");
        }
    }
}

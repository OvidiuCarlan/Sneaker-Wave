using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    [Authorize]
    public class OrderHistoryModel : PageModel
    {
        public List<OrderDTO> orders { get; set; }        
        private readonly ILogger<OrderHistoryModel> _logger;
        private readonly IOrderManager orderManager;
        public OrderHistoryModel(ILogger<OrderHistoryModel> logger, IOrderManager _orderManager)
        {
            orderManager = _orderManager;
            _logger = logger;
        }
        public void OnGet()
        {
            orders = new List<OrderDTO>();
            int userId = GetCurrentUserId();

            if(userId != 0)
            {
                orders = orderManager.GetAllOrdersForUser(userId);
            }            
        }
        //Log out function
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync();
            ClearCart();
            return RedirectToPage("Login");
        }
        public int GetCurrentUserId()
        {
            int userId;
            userId = Convert.ToInt32(User?.FindFirst("id")?.Value ?? string.Empty);
            return userId;
        }
        public string GetStatusClass(string status)
        {
            if (status == "Open")
            {
                return "status-open";
            }
            else if (status == "Processed")
            {
                return "status-processed";
            }
            else if (status == "Delivered")
            {
                return "status-delivered";
            }
            return "";
        }
        //Clears items in the shopping cart
        public void ClearCart()
        {
            HttpContext.Session.Remove("CartItems");
        }
    }
}

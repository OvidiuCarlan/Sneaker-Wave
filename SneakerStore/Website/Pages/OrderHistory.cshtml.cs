using Logic.DTOs;
using Logic.Interfaces;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
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
    }
}

using DAL.DBs;
using Logic.DTOs;
using Logic.Interfaces;
using Logic.Logic;
using Logic.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class RegisterModel : PageModel
    {
        
        [BindProperty]
        public CustomerDTO customer { get; set; }
        public string errorMessage;

        private readonly ILogger<IndexModel> _logger;
        private readonly IUserManager userManager;
        public RegisterModel(ILogger<IndexModel> logger, IUserManager _userManager)
        {
            userManager = _userManager;
            _logger = logger;
        }

        public void OnGet()
        {
            customer = new CustomerDTO();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserDataValidation.RegisterValidation(customer);
                    AddUser(customer);
                    return RedirectToPage("Login");
                }
                catch(Exception  e)
                {
                    errorMessage = e.Message;
                    return Page();
                }               
            }
            return Page();
        }
        private void AddUser(CustomerDTO customer)
        {
            userManager.AddUser(customer);
        }
    }
}

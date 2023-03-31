using DAL.DBs;
using Logic.DTOs;
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
            UserManager userManager = new UserManager(new UserDataHandler());
            userManager.AddUser(customer);
        }
    }
}

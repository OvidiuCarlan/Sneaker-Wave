using DAL.DBs;
using Logic.DTOs;
using Logic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public CustomerDTO customer { get; set; }
        public string errorMessage;
        UserManager userManager = new UserManager(new UserDataHandler());

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
                    if(userManager.Login(customer) == true)
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return Page();
                    }
                }
                catch(Exception e)
                {
                    errorMessage = e.Message;
                    return Page();
                }
            }
            return Page();
        }
    }
}

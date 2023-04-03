using DAL.DBs;
using Logic.DTOs;
using Logic.Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Website.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public CustomerDTO customerDto { get; set; }
        public string errorMessage;
        UserManager userManager = new UserManager(new UserDataHandler());

        public void OnGet()
        {
            customerDto = new CustomerDTO();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (IsUserValid())
                    {
                        Customer customer = userManager.GetCustomerByEmail(customerDto.email);

                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                            new Claim[]
                            {
                        new Claim("id", customer.Id.ToString()),
                        new Claim("firstName", customer.FirstName),
                        new Claim("lastName", customer.LastName),
                        new Claim("email", customer.Email),
                            }, CookieAuthenticationDefaults.AuthenticationScheme);
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                        await HttpContext.SignInAsync(claimsPrincipal);

                        return RedirectToPage("Profile");
                    }                   
                    return Page();
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                    return Page();
                }                                  
                
            }
            else
            {
                await HttpContext.ForbidAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Page();
            }
            
        }

        private bool IsUserValid()
        {
            bool isUserValid = false;
            try
            {
                isUserValid = userManager.Login(customerDto);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return isUserValid;
        }
    }
}

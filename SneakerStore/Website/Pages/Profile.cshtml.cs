using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        public void OnGet()
        {    
            
        }

        //Log out function
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync();
            ClearCart();
            return RedirectToPage("Login");
        }
        //Clears items in the shopping cart
        public void ClearCart()
        {
            HttpContext.Session.Remove("CartItems");
        }
    }
}

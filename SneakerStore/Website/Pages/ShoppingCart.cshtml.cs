using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class ShoppingCartModel : PageModel
    {
        public List<ShoppingCartItemDTO> cartItems { get; set; }
        public void OnGet()
        {
        }
    }
}

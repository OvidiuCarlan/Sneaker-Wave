using DAL.DBs;
using Logic.Logic;
using Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class ProductInfoModel : PageModel
    {
        public int productId { get; set; }     
        ProductManager productManager = new ProductManager(new ProductDataHandler());
        [BindProperty]
        public Product product { get; set; }

        public void OnGet(int id)
        {
            product = productManager.GetProductById(id);            
        }
    }
}

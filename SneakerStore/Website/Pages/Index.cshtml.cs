using DAL.DBs;
using Logic.Interfaces;
using Logic.Logic;
using Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {        
        private readonly ILogger<IndexModel> _logger;
                
        public List<Product> products { get; set; }
        public ProductManager productManager { get; set; }
        

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            products = new List<Product>();
            productManager = new ProductManager(new ProductDataHandler());
        }

        public void OnGet()
        {
            products = productManager.GetAll();
        }
    }
}
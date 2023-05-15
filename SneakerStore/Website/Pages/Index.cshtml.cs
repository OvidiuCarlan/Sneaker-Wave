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
        private readonly IProductManager productManager;
             
        public IndexModel(ILogger<IndexModel> logger, IProductManager _productManager)
        {
            productManager = _productManager;
            _logger = logger;
            products = new List<Product>();
        }

        public void OnGet()
        {
            products = productManager.GetAll();
        }
    }
}
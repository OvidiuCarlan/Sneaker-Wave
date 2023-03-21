using Logic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {        
        private readonly ILogger<IndexModel> _logger;


        public List<Product> products { get; set; }
        public ProductManager productManager { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            products = new List<Product>();
            productManager = new ProductManager();
        }

        public void OnGet()
        {
            products = productManager.GetAllProducts();
        }
    }
}
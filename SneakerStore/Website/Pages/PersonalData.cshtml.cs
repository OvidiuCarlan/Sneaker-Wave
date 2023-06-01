using Logic.DTOs;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Website.Pages
{
    public class PersonalDataModel : PageModel
    {
        [BindProperty]
        public CustomerDTO customer { get; set; }
        public string errorMessage { get; set; }
        private readonly ILogger<PersonalDataModel> _logger;
        public PersonalDataModel(ILogger<PersonalDataModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UserDataValidation.RegisterValidation(customer);
                    StorePersonalData(customer);
                    return RedirectToPage("Checkout");
                }
                catch (Exception e)
                {
                    errorMessage = e.Message;
                    return Page();
                }
            }
            return Page();
        }
        public void StorePersonalData(CustomerDTO customer)
        {
            string json = JsonSerializer.Serialize(customer);
            HttpContext.Session.SetString("userData", json);
        }
    }
}
 
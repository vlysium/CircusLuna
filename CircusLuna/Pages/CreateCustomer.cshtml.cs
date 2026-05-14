using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class CreateCustomerModel : PageModel
    {                
        public CreateCustomerModel()
        {            
        }

        [BindProperty]
        public Customer Customer { get; set; }

        [BindProperty]
        public string PerformanceId { get; set; }

        [BindProperty]
        public List<string> SelectedSeats { get; set; }


        public void OnGet(string performanceId, List<string> selectedSeats)
        {
            PerformanceId = performanceId;
            SelectedSeats = selectedSeats;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TempData["CustomerName"] = Customer.Name;
            TempData["CustomerEmail"] = Customer.Email;
            TempData["CustomerNumber"] = Customer.Number;

            return RedirectToPage("Confirmation", new
            {
                performanceId = PerformanceId,
                selectedSeats = SelectedSeats
            });
            
        }
    }
}

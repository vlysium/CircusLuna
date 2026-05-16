using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

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
        public List<string> SelectedSeatIds { get; set; }
        [BindProperty]
        public string TicketType { get; set; }


        public void OnGet(string performanceId, List<string> selectedSeatIds, string ticketType)
        {
            PerformanceId = performanceId;
            SelectedSeatIds = selectedSeatIds;
            TicketType = ticketType;
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
                selectedSeatIds = SelectedSeatIds,
                ticketType = TicketType
            });
            
        }      

    }
}

using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class CreateVenueModel : PageModel
    {
        private VenueService _venueService;
        public CreateVenueModel(VenueService venueService)
        {
            _venueService = venueService;
        }

        [BindProperty]
        public Venue Venue { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _venueService.AddVenue(Venue);
            return RedirectToPage("TourPlan");
        }
    }
}

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
            Venue v = new Venue(Venue.Name, Venue.VipSeats, Venue.StandardSeats);
            _venueService.AddVenue(v);
            return RedirectToPage("TourPlan");
        }
    }
}

using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for creating and registering new circus venues.
    /// Handles capturing venue metadata and managing the initial capacity configuration for seat tiers.
    /// </summary>
    public class CreateVenueModel : PageModel
    {
        private readonly VenueService _venueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVenueModel"/> class.
        /// </summary>
        /// <param name="venueService">The service used to manage and persist venue configuration data.</param>
        public CreateVenueModel(VenueService venueService)
        {
            _venueService = venueService;
        }

        /// <summary>
        /// Gets or sets the venue data model containing structural and capacity details.
        /// Bound from the incoming form submission.
        /// </summary>
        [BindProperty]
        public Venue Venue { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to render the empty venue creation form.
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Handles HTTP POST requests to validate and persist a new venue profile.
        /// Instantiates a clean venue structure using the bound capacity values before database insertion.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> that redirects back to the 'TourPlan' dashboard.</returns>
        public IActionResult OnPost()
        {
            
            Venue v = new Venue(Venue.Name, Venue.VipSeats, Venue.StandardSeats);
            _venueService.AddVenue(v);
            return RedirectToPage("TourPlan");
        }
    }
}
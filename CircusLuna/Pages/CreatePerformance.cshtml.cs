using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for organizing and scheduling new circus performances.
    /// Handles binding metadata (name, date, location) and associating available 
    /// venues and participating artists with the performance.
    /// </summary>
    public class CreatePerformanceModel : PageModel
    {
        private readonly PerformanceService _pService;
        private readonly PersonService _personService;
        private readonly VenueService _venueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePerformanceModel"/> class.
        /// </summary>
        /// <param name="performanceService">The service used to register and store performance data.</param>
        /// <param name="personService">The service used to retrieve active roster profiles like artists.</param>
        /// <param name="venueService">The service used to fetch structural physical venue records.</param>
        public CreatePerformanceModel(PerformanceService performanceService, PersonService personService, VenueService venueService)
        {
            _pService = performanceService;
            _personService = personService;
            _venueService = venueService;
        }

        /// <summary>
        /// Gets or sets the public-facing title or headline of the performance event.
        /// </summary>
        [BindProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a descriptive summary highlighting features of the performance.
        /// </summary>
        [BindProperty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the target calendar date and showtime for the performance.
        /// Defaults to the system's local current timestamp on instantiation.
        /// </summary>
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the geographic territory or jurisdiction enum value where the show takes place.
        /// </summary>
        [BindProperty]
        public Region? Region { get; set; }

        /// <summary>
        /// Gets or sets the name of the municipality hosting the performance site.
        /// </summary>
        [BindProperty]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the postal/ZIP sorting code associated with the city.
        /// </summary>
        [BindProperty]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the unique identity list of artists checked off to perform in this event.
        /// Bound from multiple checkbox form fields.
        /// </summary>
        [BindProperty]
        public List<string> SelectedArtistIds { get; set; }

        /// <summary>
        /// Gets or sets the specific venue identifier targeted to host the production setup.
        /// Bound from a select dropdown structure.
        /// </summary>
        [BindProperty]
        public string? SelectedVenueId { get; set; }

        /// <summary>
        /// Gets or sets the global collection of all registered database artists.
        /// Used to build dynamic selection components in the presentation view markup.
        /// </summary>
        public List<Artist> AllArtists { get; set; }

        /// <summary>
        /// Gets or sets the global collection of all registered structural venue setups.
        /// Used to build dynamic selection components in the presentation view markup.
        /// </summary>
        public List<Venue> AllVenues { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to provision selection controls with initial metadata lookups.
        /// </summary>
        public void OnGet()
        {
            AllArtists = _personService.GetAllArtists() ?? new List<Artist>();
            AllVenues = _venueService.GetAll() ?? new List<Venue>();
        }

        /// <summary>
        /// Handles HTTP POST requests to validate input data and finalize the creation of a performance.
        /// Maps individual flat inputs into unified model structures before submitting to data persistence.
        /// </summary>
        /// <returns>
        /// The current view page with repopulated dynamic menu components if validation fails; 
        /// otherwise, a redirect to the scheduled <c>TourPlan</c> dashboard page.
        /// </returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // CRITICAL: Collections must be repopulated if returning the page,
                // otherwise the dropdown and checkboxes will crash with a NullReferenceException.
                AllArtists = _personService.GetAllArtists();
                AllVenues = _venueService.GetAll();
                return Page();
            }

            // list of string Ids used to return list of Artist objects using the service layer helper method
            List<Artist> selectedArtists = _personService.SelectedArtistsStringToArtist(SelectedArtistIds);

            
            Performance newPerformance = new Performance(
                Name,
                Description,
                Date,
                SelectedVenueId!,
                new City(City, PostalCode, Region!.Value),
                selectedArtists);

            _pService.AddPerformance(newPerformance);
            return RedirectToPage("TourPlan");
        }
    }
}
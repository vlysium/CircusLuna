using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CircusLuna.Pages
{
    public class CreatePerformanceModel : PageModel
    {
        
        private PerformanceService _pService;
        private PersonService _personService;
        private VenueService _venueService;

        public CreatePerformanceModel(PerformanceService performanceService, PersonService personService, VenueService venueService)
        {
            _pService = performanceService;
            _personService = personService;
            _venueService = venueService;
        }

        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;
        [BindProperty]
        public Region? Region { get; set; }
        [BindProperty]
        public string City { get; set; }
        [BindProperty]
        public string PostalCode { get; set; }
 

        [BindProperty]
        public List<string> SelectedArtistIds { get; set; }
        [BindProperty]
        public string? SelectedVenueId { get; set; }


        public List<Artist> AllArtists { get; set; }
        public List<Venue> AllVenues { get; set; }

        public void OnGet()
        {
            AllArtists = _personService.GetAllArtists() ?? new List<Artist>();
            AllVenues = _venueService.GetAll() ?? new List<Venue>();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // CRITICAL: You must repopulate collections if returning the page,
                // otherwise the dropdown and checkboxes will crash with a NullReferenceException.
                AllArtists = _personService.GetAllArtists();
                AllVenues = _venueService.GetAll();
                return Page();
            }
            List<Artist> allArtists = _personService.GetAllArtists();
            List<Artist> SelectedArtists = new List<Artist>();
            if (SelectedArtistIds == null)
            {
                SelectedArtistIds = new List<string>();
            }

            foreach (Artist a in allArtists)
            {
                if (SelectedArtistIds.Contains(a.ID))
                {
                    SelectedArtists.Add(a);
                }
            }       


            
            Performance newPerformance = new Performance(
                Name,
                Description,
                Date,
                SelectedVenueId!,
                new City(City, PostalCode, Region!.Value),
                SelectedArtists);

            _pService.AddPerformance(newPerformance);
            return RedirectToPage("TourPlan");
        }
    }
}

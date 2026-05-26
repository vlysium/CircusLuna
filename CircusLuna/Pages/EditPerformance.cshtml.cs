using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CircusLuna.Pages
{
    public class EditPerformanceModel : PageModel
    {
        
        private PerformanceService _performanceService;
        private PersonService _personService;
        private VenueService _venueService;

        public EditPerformanceModel(PerformanceService performanceService, PersonService personService, VenueService venueService)
        {
            _performanceService = performanceService;
            _personService = personService;
            _venueService = venueService;
        }
        [BindProperty]
        public Performance Performance { get; set; }

        [BindProperty]
        public List<string> SelectedArtistIds { get; set; } = new List<string>();

        public List<Artist> AllArtists { get; set; }
        public List<Venue> AllVenues { get; set; }

        public void OnGet(string id)
        {
            Performance = _performanceService.GetPerformance(id);
            AllArtists = _personService.GetAllArtists();
            AllVenues = _venueService.GetAll();
            
            foreach (var artist in Performance.Artists)
            {
                SelectedArtistIds.Add(artist.ID);
            }
        }

        public IActionResult OnPost()
        {
            // 
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

            Performance.Artists = SelectedArtists;

            _performanceService.UpdatePerformance(Performance);
            return RedirectToPage("TourPlan");
        }
    }
}

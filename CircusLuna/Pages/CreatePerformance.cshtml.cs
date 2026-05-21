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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;        
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

            for (int i = 0; i<allArtists.Count; i++)
            {
                for(int j=0; j < SelectedArtistIds.Count; j++)
                {
                    if (allArtists[i].ID == SelectedArtistIds[j])
                    {
                        SelectedArtists.Add(allArtists[i]);
                        break; //found a match - move on to the next.
                    }
                }
            }

            //Simpler and more readable loop
            //foreach(Artist a in allArtists)
            //{
            //    if (SelectedArtistIds.Contains(a.ID))
            //    {
            //        SelectedArtists.Add(a);
            //    }
            //}

            
            Performance newPerformance = new Performance(
                Date,           // 1. DateTime date
                Name,           // 2. string name
                SelectedVenueId,          // 3. string venueId
                new City(City, PostalCode), // 4. City city
                SelectedArtists); // 5. List<Artist> artists

            _pService.AddPerformance(newPerformance);
            return RedirectToPage("TourPlan");
        }
    }
}

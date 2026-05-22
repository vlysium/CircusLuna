using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class TourPlanModel : PageModel
    {
        public List<Performance> Performances { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedRegion { get; set; }

        public List<Artist> Artists { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedArtist { get; set; }

        // A dictionary that maps sort option keys to their display names for use in the UI
        public Dictionary<string, string> SortOptions { get; } = new Dictionary<string, string>
        {
            { "city_asc", "City (A-Z)" },
            { "city_dsc", "City (Z-A)" },
            { "name_asc", "Name (A-Z)" },
            { "name_dsc", "Name (Z-A)" },
            { "date_asc", "Date (Oldest first)" },
            { "date_dsc", "Date (Newest first)" }
        };

        private readonly PerformanceService _performanceService;
        private readonly PersonService _personService;

        public TourPlanModel(PerformanceService performanceService, PersonService personService)
        {
            _performanceService = performanceService;
            _personService = personService;
        }

        public void OnGet()
        {
            Artists = _personService.GetAllArtists();

            Performances = _performanceService.GetAllPerformances();

            // If a region or artist filter is selected, filter the performances accordingly
            Performances = _performanceService.FilterPerformances(
                Performances,
                Enum.TryParse(SelectedRegion, out Region region) ? region : null,
                (Artist)_personService.GetById(SelectedArtist)
            );

            // If a search term is provided, search for performances that match the term
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Performances = _performanceService.SearchPerformances(Performances, SearchTerm);
            }


            // If a sortby parameter is provided, sort the performances accordingly
            if (!string.IsNullOrEmpty(SortBy))
            {
                switch (SortBy)
                {
                    case "city_asc":
                        Performances = _performanceService.SortPerformances(Performances, PerformanceSortOption.CityName, ascending: true);
                        break;

                    case "city_dsc":
                        Performances = _performanceService.SortPerformances(Performances, PerformanceSortOption.CityName, ascending: false);
                        break;

                    case "name_asc":
                        Performances = _performanceService.SortPerformances(Performances, PerformanceSortOption.PerformanceName, ascending: true);
                        break;

                    case "name_dsc":
                        Performances = _performanceService.SortPerformances(Performances, PerformanceSortOption.PerformanceName, ascending: false);
                        break;

                    case "date_asc":
                        Performances = _performanceService.SortPerformances(Performances, PerformanceSortOption.PerformanceDate, ascending: true);
                        break;

                    case "date_dsc":
                        Performances = _performanceService.SortPerformances(Performances, PerformanceSortOption.PerformanceDate, ascending: false);
                        break;

                    default:
                        // If an unknown sort option is provided, do not sort the performances
                        break;
                }
            }
        }
    }
}

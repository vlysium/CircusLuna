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

        private readonly PerformanceService _performanceService;

        public TourPlanModel(PerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        public void OnGet()
        {
            // If no search term is provided, get all performances
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Performances = _performanceService.GetAllPerformances();
            }
            // If a search term is provided, search for performances that match the term
            else
            {
                Performances = _performanceService.SearchPerformances(SearchTerm);
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

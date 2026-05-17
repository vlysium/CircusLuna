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
        }
    }
}

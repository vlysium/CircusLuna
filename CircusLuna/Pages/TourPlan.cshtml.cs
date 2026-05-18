using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class TourPlanModel : PageModel
    {
        public List<Performance> Performances { get; set; }
        [BindProperty]
        public string performanceId { get; set; }

        private readonly PerformanceService _performanceService;

        public TourPlanModel(PerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        public void OnGet()
        {
            Performances = _performanceService.GetAllPerformances();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("BookSeats", new { performanceId = performanceId });
        }
    }
}

using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class PerformanceDetailsModel : PageModel
    {
        public Performance Performance { get; set; }
        private readonly PerformanceService _performanceService;
        public PerformanceDetailsModel(PerformanceService performanceService)
        {
            _performanceService = performanceService;
        }
        public void OnGet(string id)
        {
            try
            {
                Performance = _performanceService.GetPerformance(id);
            }
            catch (Exception ex)
            {
                RedirectToPage("/tour-plan");
            }
        }
    }
}

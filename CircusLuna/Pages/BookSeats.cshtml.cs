using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class BookSeatsModel : PageModel
    {
        private readonly PerformanceService _performanceService;
        private readonly ReservationService _reservationService;

        public Performance CurrentPerformance { get; set; }
        public List<string> BusySeatIds { get; set; }

        public BookSeatsModel(PerformanceService pService, ReservationService rService)
        {
            _performanceService = pService;
            _reservationService = rService;
        }

        public void OnGet(string id)
        {
            CurrentPerformance = _performanceService.GetPerformance(id);
            BusySeatIds = _reservationService.GetBusySeatIds(id);
        }

        public IActionResult OnPost(string performanceId, List<string> selectedSeatIds)
        {
            if (selectedSeatIds == null || !selectedSeatIds.Any()) return Page();

            // Pass data to CreateCustomer via Redirect with Route Values
            return RedirectToPage("CreateCustomer", new
            {
                performanceId = performanceId,
                selectedSeats = selectedSeatIds
            });
        }
    }
}

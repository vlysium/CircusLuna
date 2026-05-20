using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace CircusLuna.Pages
{
    public class BookSeatsModel : PageModel
    {
        private readonly PerformanceService _performanceService;
        private readonly ReservationService _reservationService;
        public BookSeatsModel(PerformanceService pService, ReservationService rService)
        {
            _performanceService = pService;
            _reservationService = rService;
        }

        public Performance CurrentPerformance { get; set; }
        public List<string> BusySeatIds { get; set; }
        public List<Seat> AllSeats { get; set; }


        [BindProperty]
        public string PerformanceId { get; set; }
        [BindProperty]
        public string TicketType { get; set; }
        [BindProperty]
        public List<string> SelectedSeatIds { get; set; }
             

        public void OnGet(string performanceId)
        {
            CurrentPerformance = _performanceService.GetPerformance(performanceId);
            BusySeatIds = _reservationService.GetBusySeatIds(performanceId);
            AllSeats = _performanceService.GetSeats();
        }

        public IActionResult OnPost(string performanceId, List<string> SelectedSeatIds, string ticketType)
        {
            if (SelectedSeatIds == null || SelectedSeatIds.Count==0)
            {
                OnGet(performanceId);
                return Page();
            }

            // Pass data to CreateCustomer via Redirect with Route Values
            return RedirectToPage("CreateCustomer", new
            {
                performanceId = performanceId,
                selectedSeatIds = SelectedSeatIds,
                ticketType = ticketType
            });
        }
    }
}

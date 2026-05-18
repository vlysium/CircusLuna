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
        private readonly VenueService _venueService;
        public BookSeatsModel(PerformanceService pService, ReservationService rService, VenueService venueService)
        {
            _performanceService = pService;
            _reservationService = rService;
            _venueService = venueService;
        }

        public Performance CurrentPerformance { get; set; }
        public List<Seat> Seats { get; set; }
        
        public List<string> BusySeatIds { get; set; }


        [BindProperty]
        public string PerformanceId { get; set; }
        [BindProperty]
        public string TicketType { get; set; }
        [BindProperty]
        public List<string> SelectedSeatIds { get; set; }
             

        public void OnGet(string performanceId)
        {
            PerformanceId = performanceId;
            CurrentPerformance = _performanceService.GetPerformance(performanceId);
            BusySeatIds = _reservationService.GetBusySeatIds(performanceId);
            Seats = _venueService.GetVenue().AllSeats;            
        }

        public IActionResult OnPost()
        {
            if (SelectedSeatIds == null || SelectedSeatIds.Count==0)
            {
                OnGet(PerformanceId);
                ModelState.AddModelError(string.Empty, "Du skal vælge mindst én siddeplads.");
                return Page();
            }

            // Pass data to CreateCustomer via Redirect with Route Values
            return RedirectToPage("CreateCustomer", new
            {
                performanceId = PerformanceId,
                selectedSeatIds = SelectedSeatIds,
                ticketType = TicketType
            });
        }
    }
}

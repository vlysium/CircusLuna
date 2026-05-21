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
        public List<string> BusySeatIds { get; set; }
        public Venue CurrentVenue { get; set; }


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
            CurrentVenue = _venueService.GetById(CurrentPerformance.VenueId);            
        }

        public IActionResult OnPost()
        {
            if (SelectedSeatIds == null || SelectedSeatIds.Count==0)
            {
                OnGet(PerformanceId);
                return Page();
            }

            
            return RedirectToPage("CreateCustomer", new
            {
                performanceId = PerformanceId,
                selectedSeatIds = SelectedSeatIds,
                ticketType = TicketType
            });
        }
    }
}

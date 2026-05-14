using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class ConfirmationModel : PageModel
    {
        private readonly ReservationService _rService;
        private readonly PerformanceService _pService;

        public Performance Performance { get; set; }
        public List<string> SeatIds { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustNumber { get; set; }

        public ConfirmationModel(ReservationService rService, PerformanceService pService)
        {
            _rService = rService;
            _pService = pService;
        }

        public void OnGet(string performanceId, List<string> selectedSeats)
        {
            Performance = _pService.GetPerformance(performanceId);
            SeatIds = selectedSeats;
            CustName = TempData["CustomerName"]?.ToString();
            CustEmail = TempData["CustomerEmail"]?.ToString();
            CustNumber = TempData["CustomerNumber"]?.ToString();

            TempData.Keep(); //Keeps TempData alive for the Post
        }

        public IActionResult OnPost(string performanceId, List<string> seatIds)
        {
            Performance performance = _pService.GetPerformance(performanceId);
            Customer customer = new Customer(TempData["CustomerName"].ToString(), TempData["CustomerEmail"].ToString(), TempData["CustomerNumber"].ToString());

            // 1. Create Tickets
            List<Ticket> tickets = seatIds.Select(id =>
                new Ticket(TicketType.Standard, performance.Venue.AllSeats.First(s => s.SeatId == id))
            ).ToList();

            // 2. Create and Save Reservation
            Reservation finalRes = new Reservation(customer, performance, tickets);
            _rService.AddReservation(finalRes);

            return RedirectToPage("Success");
        }
    }
}

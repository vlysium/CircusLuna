using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;

namespace CircusLuna.Pages
{
    public class ConfirmationModel : PageModel
    {
        private readonly ReservationService _reservationService;
        private readonly PerformanceService _performanceService;
        private readonly VenueService _venueService;

        public ConfirmationModel(ReservationService reservationService, PerformanceService performanceService, VenueService venueService)
        {
            _reservationService = reservationService;
            _performanceService = performanceService;
            _venueService = venueService;
        }


        [BindProperty]
        public string PerformanceId { get; set; }
        [BindProperty]
        public string TicketTypeString { get; set; }
        [BindProperty]
        public List<string> SeatIds { get; set; }

        [BindProperty]
        public string CustomerName { get; set; }
        [BindProperty]
        public string CustomerEmail { get; set; }
        [BindProperty]
        public string CustomerNumber { get; set; }


        public double TotalPrice { get; set; }
        public Performance Performance { get; set; }
           


        public void OnGet(string performanceId, List<string> selectedSeatIds, string ticketTypeString)
        {
            PerformanceId = performanceId;             
            SeatIds = selectedSeatIds;
            TicketTypeString = ticketTypeString;

            
            //DATA FOR DISPLAY ***************************************************************************
            Performance = _performanceService.GetPerformance(performanceId);
            CustomerName = TempData["CustomerName"]?.ToString();            
            CustomerEmail = TempData["CustomerEmail"]?.ToString();
            CustomerNumber = TempData["CustomerNumber"]?.ToString();
            //we have to create the properties, that are saved in tempdata, tempdata is destroyed on first refresh.


            List<Ticket> tempTickets = _reservationService.CreateTickets(Performance.VenueId, SeatIds, TicketTypeString);
            Customer tempCust = new Customer(CustomerName ?? "", "", ""); 
            Reservation previewRes = new Reservation(tempCust, Performance, tempTickets);
            TotalPrice = previewRes.TotalPrice; //display prices before confirmation
            


            TempData.Keep(); //Keeps TempData alive for the Post
        }

        public IActionResult OnPost()
        {
            Performance performance = _performanceService.GetPerformance(PerformanceId);            
            Customer customer = new Customer(CustomerName, CustomerNumber, CustomerEmail);
            List<Ticket> tickets = _reservationService.CreateTickets(performance.VenueId, SeatIds, TicketTypeString);    
           
            Reservation finalRes = new Reservation(customer, performance, tickets);
            _reservationService.AddReservation(finalRes);

            return RedirectToPage("Index");
        }
    }
}

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



        public double TotalPrice { get; set; }
        public Performance Performance { get; set; }
        [BindProperty]
        public string CustomerName { get; set; }
        [BindProperty]
        public string CustomerEmail { get; set; }
        [BindProperty]
        public string CustomerNumber { get; set; }        

       

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



            // --- Calculate Price for Display ------------------------------------------------------------
            TicketType TicketTypeEnum = _reservationService.StringToTicketType(TicketTypeString);

            Venue venue = _venueService.GetById(Performance.VenueId);
            List<Ticket> tempTickets = _reservationService.CreateTickets(venue, SeatIds, TicketTypeEnum);

            // Create a dummy customer for the preview
            Customer tempCust = new Customer(CustomerName ?? "", "", "");

            // This triggers your automatic calculation logic
            Reservation previewRes = new Reservation(tempCust, Performance, tempTickets);
            TotalPrice = previewRes.TotalPrice;
            


            TempData.Keep(); //Keeps TempData alive for the Post
        }

        public IActionResult OnPost()
        {
            Performance performance = _performanceService.GetPerformance(PerformanceId);
            
            Customer customer = new Customer(CustomerName, CustomerNumber, CustomerEmail);

            // Create Tickets
            TicketType TicketTypeEnum = _reservationService.StringToTicketType(TicketTypeString);
            Venue venue = _venueService.GetById(performance.VenueId);
            List<Ticket> tickets = _reservationService.CreateTickets(venue, SeatIds, TicketTypeEnum);      

            // Create and Save Reservation
            Reservation finalRes = new Reservation(customer, performance, tickets);
            _reservationService.AddReservation(finalRes);

            return RedirectToPage("Index");
        }
    }
}

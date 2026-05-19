using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;

namespace CircusLuna.Pages
{
    public class ConfirmationModel : PageModel
    {
        private readonly ReservationService _rService;
        private readonly PerformanceService _pService;
        private readonly VenueService _venueService;

        public ConfirmationModel(ReservationService rService, PerformanceService pService, VenueService venueService)
        {
            _rService = rService;
            _pService = pService;
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
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustNumber { get; set; }        

       

        public void OnGet(string performanceId, List<string> selectedSeatIds, string ticketType)
        {
            PerformanceId = performanceId;             
            SeatIds = selectedSeatIds;
            TicketTypeString = ticketType;

            
            //data for display
            Performance = _pService.GetPerformance(performanceId);
            CustName = TempData["CustomerName"]?.ToString();
            CustEmail = TempData["CustomerEmail"]?.ToString();
            CustNumber = TempData["CustomerNumber"]?.ToString();



            // --- Calculate Price for Display ---
            if (!Enum.TryParse(TicketTypeString, out TicketType chosenType))
            {
                chosenType = TicketType.Standard; // Default fallback
            }

            Venue venue = _venueService.GetById(Performance.VenueId);
            List<Ticket> tempTickets = new List<Ticket>();
            foreach (string id in SeatIds)
            {
                foreach (Seat s in venue.Seats)
                {
                    if (s.SeatId == id)
                    {
                        tempTickets.Add(new Ticket(chosenType, s));
                    }
                }
            }

            // Create a dummy customer for the preview
            Customer tempCust = new Customer(CustName ?? "", "", "");

            // This triggers your automatic calculation logic
            Reservation previewRes = new Reservation(tempCust, Performance, tempTickets);
            TotalPrice = previewRes.TotalPrice;
            



            TempData.Keep(); //Keeps TempData alive for the Post
        }

        public IActionResult OnPost()
        {
            Performance performance = _pService.GetPerformance(PerformanceId);

            //create customer from TempData
            string name = TempData["CustomerName"]?.ToString() ?? "Guest";
            string email = TempData["CustomerEmail"]?.ToString() ?? "";
            string phone = TempData["CustomerNumber"]?.ToString() ?? "";
            Customer customer = new Customer(name, email, phone);           

            //Convert our ticketTypeString into enum TicketType.
            if (!Enum.TryParse(TicketTypeString, out TicketType chosenType))
            {
                chosenType = TicketType.Standard; // Default fallback
            }

            // Create Tickets
            Venue venue = _venueService.GetById(performance.VenueId);
            List<Ticket> tickets = new List<Ticket>();
            foreach(string seatId in SeatIds)
            {
                foreach(Seat s in venue.Seats)
                {                    
                    if (s.SeatId == seatId)
                    {                         
                        Ticket t = new Ticket(chosenType,s);
                        tickets.Add(t);
                        break;
                    }
                }
            }            

            // Create and Save Reservation
            Reservation finalRes = new Reservation(customer, performance, tickets);
            _rService.AddReservation(finalRes);

            return RedirectToPage("Index");
        }
    }
}

using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Sockets;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for the final booking confirmation step.
    /// Handles rendering the booking preview summary, calculating the total price, 
    /// and persisting the finalized reservation to the database.
    /// </summary>
    public class ConfirmationModel : PageModel
    {
        private readonly ReservationService _reservationService;
        private readonly PerformanceService _performanceService;
        private readonly VenueService _venueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmationModel"/> class.
        /// </summary>
        /// <param name="reservationService">The service used to process and save reservations.</param>
        /// <param name="performanceService">The service used to retrieve performance details.</param>
        /// <param name="venueService">The service used to access physical venue configurations.</param>
        public ConfirmationModel(ReservationService reservationService, PerformanceService performanceService, VenueService venueService)
        {
            _reservationService = reservationService;
            _performanceService = performanceService;
            _venueService = venueService;
        }

        /// <summary>
        /// Gets or sets the unique identifier of the selected performance.
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public string PerformanceId { get; set; }

        /// <summary>
        /// Gets or sets the string representation of the chosen ticket type/tier.
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public string TicketTypeString { get; set; }

        /// <summary>
        /// Gets or sets the list of chosen seat identifiers for this booking.
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public List<string> SeatIds { get; set; }

        /// <summary>
        /// Gets or sets the full name of the customer making the reservation.
        /// Bound from the incoming form or temporary session data.
        /// </summary>
        [BindProperty]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the customer making the reservation.
        /// Bound from the incoming form or temporary session data.
        /// </summary>
        [BindProperty]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the contact telephone number of the customer making the reservation.
        /// Bound from the incoming form or temporary session data.
        /// </summary>
        [BindProperty]
        public string CustomerNumber { get; set; }

        /// <summary>
        /// Gets or sets the calculated total cost of the booking preview.
        /// Used strictly for UI display purposes.
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the specific circus performance associated with this booking.
        /// Used strictly for UI display purposes.
        /// </summary>
        public Performance Performance { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to display the confirmation preview page.
        /// Pulls customer data out of <see cref="ITempDataDictionary"/> and sets up pricing models.
        /// </summary>
        /// <param name="performanceId">The ID of the target performance.</param>
        /// <param name="selectedSeatIds">The list of seats chosen in the previous step.</param>
        /// <param name="ticketTypeString">The selected category/tier of tickets.</param>
        public void OnGet(string performanceId, List<string> selectedSeatIds, string ticketTypeString)
        {
            PerformanceId = performanceId;
            SeatIds = selectedSeatIds;
            TicketTypeString = ticketTypeString;

            // DATA FOR DISPLAY ***************************************************************************
            Performance = _performanceService.GetPerformance(performanceId);
            CustomerName = TempData["CustomerName"]?.ToString();
            CustomerEmail = TempData["CustomerEmail"]?.ToString();
            CustomerNumber = TempData["CustomerNumber"]?.ToString();

            // Generate a transient reservation preview to calculate totals dynamically for the view
            List<Ticket> tempTickets = _reservationService.CreateTickets(Performance.VenueId, SeatIds, TicketTypeString);
            Customer tempCust = new Customer(CustomerName ?? "", "", "");
            Reservation previewRes = new Reservation(tempCust, Performance, tempTickets);
            TotalPrice = previewRes.TotalPrice;

            // Ensures TempData values are not dropped after this request lifecycle, keeping them available for the OnPost handler
            TempData.Keep();
        }

        /// <summary>
        /// Handles HTTP POST requests when the user explicitly clicks the final purchase/confirm button.
        /// Compiles the customer details, structural ticket list, and commits the finalized reservation.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> redirecting to the home page application root.</returns>
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
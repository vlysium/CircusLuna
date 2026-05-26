using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for the seat booking process.
    /// Handles retrieving performance details, occupied seats, and managing user seat selections.
    /// </summary>
    public class BookSeatsModel : PageModel
    {
        private readonly PerformanceService _performanceService;
        private readonly ReservationService _reservationService;
        private readonly VenueService _venueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookSeatsModel"/> class.
        /// </summary>
        /// <param name="pService">The service used to manage and query circus performances.</param>
        /// <param name="rService">The service used to manage seat reservations and availability.</param>
        /// <param name="venueService">The service used to retrieve layouts and data for circus venues.</param>
        public BookSeatsModel(PerformanceService pService, ReservationService rService, VenueService venueService)
        {
            _performanceService = pService;
            _reservationService = rService;
            _venueService = venueService;
        }

        /// <summary>
        /// Gets or sets the circus performance currently being booked.
        /// </summary>
        public Performance CurrentPerformance { get; set; }

        /// <summary>
        /// Gets or sets the list of identifiers for seats that are already reserved or occupied.
        /// </summary>
        public List<string> BusySeatIds { get; set; }

        /// <summary>
        /// Gets or sets the physical venue where the current performance takes place.
        /// </summary>
        public Venue CurrentVenue { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the selected performance.
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public string PerformanceId { get; set; }

        /// <summary>
        /// Gets or sets the tier or type of ticket selected by the user (e.g., VIP, Standard, Child).
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public string TicketType { get; set; }

        /// <summary>
        /// Gets or sets the list of seat identifiers chosen by the user during the booking process.
        /// Bound from the incoming request form.
        /// </summary>
        [BindProperty]
        public List<string> SelectedSeatIds { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to initialize the seat selection view for a specific performance.
        /// </summary>
        /// <param name="performanceId">The unique identifier of the performance to display.</param>
        public void OnGet(string performanceId)
        {
            PerformanceId = performanceId;
            CurrentPerformance = _performanceService.GetPerformance(performanceId);
            BusySeatIds = _reservationService.GetBusySeatIds(performanceId);
            CurrentVenue = _venueService.GetById(CurrentPerformance.VenueId);
        }

        /// <summary>
        /// Handles HTTP POST requests when a user attempts to submit their seat selections.
        /// Validation ensures at least one seat is chosen before proceeding to customer creation.
        /// </summary>
        /// <returns>
        /// The current page view if no seats are selected; 
        /// otherwise, a redirect to the 'CreateCustomer' page with route data.
        /// </returns>
        public IActionResult OnPost()
        {
            if (SelectedSeatIds == null || SelectedSeatIds.Count == 0)
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
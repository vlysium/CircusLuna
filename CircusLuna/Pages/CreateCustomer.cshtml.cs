using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for capturing customer information.
    /// Temporarily stores customer contact details using TempData and forwards 
    /// the booking configuration variables to the final confirmation page.
    /// </summary>
    public class CreateCustomerModel : PageModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerModel"/> class.
        /// </summary>
        public CreateCustomerModel()
        {
        }

        /// <summary>
        /// Gets or sets the customer domain model containing contact information (Name, Email, Phone).
        /// Bound from the incoming form submission.
        /// </summary>
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        // Example Regex: Enforces exactly 8 digits (Standard for Denmark/Scandinavia)
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Phone number must be exactly 8 digits without spaces.")]
        public string Number { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email address is required.")]
        // 2. Enforces strict server-side email pattern matching (.com, .dk, etc.)
        [EmailAddress(ErrorMessage = "Invalid email format. Example: name@domain.com")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the selected performance.
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public string PerformanceId { get; set; }

        /// <summary>
        /// Gets or sets the list of seat identifiers selected by the user.
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public List<string> SelectedSeatIds { get; set; }

        /// <summary>
        /// Gets or sets the selected ticket type/tier tier for the booking.
        /// Bound from the incoming request.
        /// </summary>
        [BindProperty]
        public string TicketType { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to capture the state of the booking from the previous step.
        /// </summary>
        /// <param name="performanceId">The unique identifier of the target performance.</param>
        /// <param name="selectedSeatIds">The list of seats selected by the customer.</param>
        /// <param name="ticketType">The chosen tier type of the tickets.</param>
        public void OnGet(string performanceId, List<string> selectedSeatIds, string ticketType)
        {
            PerformanceId = performanceId;
            SelectedSeatIds = selectedSeatIds;
            TicketType = ticketType;
        }

        /// <summary>
        /// Handles HTTP POST requests when the customer submits their contact details.
        /// Validates input, provisions temporary server-side/cookie storage via TempData to keep the URL clean,
        /// and transfers the positional reservation parameters to the confirmation page.
        /// </summary>
        /// <returns>
        /// The current page view if model validation fails; 
        /// otherwise, a redirect to the 'Confirmation' page accompanied by route parameters.
        /// </returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // This data is saved for ONE redirect lifecycle, safely on the server side or encrypted in a cookie.
            // This architecture keeps highly sensitive/longer customer string structures out of the visible URL query.
            TempData["CustomerName"] = Name;
            TempData["CustomerEmail"] = Email;
            TempData["CustomerNumber"] = Number;

            // The routing properties passed anonymously here will explicitly appear in the destination URL query string.
            return RedirectToPage("Confirmation", new
            {
                performanceId = PerformanceId,
                selectedSeatIds = SelectedSeatIds,
                ticketType = TicketType
            });
        }
    }
}
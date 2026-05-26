using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model responsible for handling the creation of personnel records.
    /// Manages client-side and server-side validation, and programmatically splits 
    /// inputs to persist either as an administrative <see cref="Employee"/> or an <see cref="Artist"/> performer.
    /// </summary>
    public class CreateEmployeeModel : PageModel
    {
        private readonly PersonService _personService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEmployeeModel"/> class.
        /// </summary>
        /// <param name="personService">The service used to register and persist person records.</param>
        public CreateEmployeeModel(PersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Gets or sets the name of the individual.
        /// </summary>
        [BindProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// Validated on both client and server to ensure a proper email structure.
        /// </summary>
        [BindProperty]
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format. Example: name@domain.com")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the telephone contact number.
        /// Enforces an exact 8-digit pattern matching Scandinavian and Danish standard communication configurations.
        /// </summary>
        [BindProperty]
        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Phone number must be exactly 8 digits without spaces.")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the operational performance designation or organizational job title.
        /// </summary>
        [BindProperty]
        public string Role { get; set; }

        /// <summary>
        /// Gets or sets the banking routing or financial settlement metadata used for payroll processing.
        /// </summary>
        [BindProperty]
        public string PaymentInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the target individual maintains a permanent contract staff status.
        /// Only evaluated if <see cref="Employee"/> is set to <see langword="false"/> (signifying an <see cref="Artist"/>).
        /// </summary>
        [BindProperty]
        public bool IsPermanent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the new person should be classified 
        /// as an internal administrative employee rather than an independent performing artist.
        /// </summary>
        [BindProperty]
        public bool Employee { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to render the empty employee or artist creation form.
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Handles HTTP POST requests to validate form inputs and persist the record.
        /// Evaluates the <see cref="ModelState"/> framework and programmatically roots data into either 
        /// an <see cref="Employee"/> or <see cref="Artist"/> entity type based on user flags.
        /// </summary>
        /// <returns>
        /// The current page view if model validation checks fail; 
        /// otherwise, redirects to the admin panel overview page view upon successful entity mapping.
        /// </returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           
            if (Employee)
            {
                Employee newEmployee = new Employee(PaymentInfo, Role, Name, Number, Email);
                _personService.AddPerson(newEmployee);
            }
            else
            {
                Artist newArtist = new Artist(PaymentInfo, Role, IsPermanent, Name, Number, Email);
                _personService.AddPerson(newArtist);
            }

            return RedirectToPage("Admin");
        }
    }
}
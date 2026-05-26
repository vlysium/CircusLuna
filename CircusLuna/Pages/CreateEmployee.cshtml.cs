using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for adding new personnel to the circus registry.
    /// Handles the creation of either independent <see cref="Artist"/> profiles 
    /// or formal internal <see cref="Employee"/> personnel types based on user selection.
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
        /// Gets or sets the artist data model captured from the creation form.
        /// Acts as the base data source even if an employee type is selected.
        /// </summary>
        [BindProperty]
        public Artist Artist { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the new person should be classified 
        /// as a internal/formal employee rather than an independent artist.
        /// </summary>
        [BindProperty]
        public bool Employee { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to render the empty employee/artist creation form.
        /// </summary>
        public void OnGet()
        {
        }

        /// <summary>
        /// Handles HTTP POST requests to save the new personnel entry.
        /// Inspects the <see cref="Employee"/> flag to dynamically downcast/map 
        /// the form data into the appropriate database entity before saving.
        /// </summary>
        /// <returns>
        /// The current form view if model states are invalid; 
        /// otherwise, a redirect back to the 'Admin' dashboard.
        /// </returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Employee)
            {
                // Map fields over to an official Employee structure if designated
                Employee newEmployee = new Employee
                {
                    ID = Artist.ID,
                    Name = Artist.Name,
                    Email = Artist.Email,
                    Number = Artist.Number,
                    Role = Artist.Role,
                    PaymentInfo = Artist.PaymentInfo
                };
                _personService.AddPerson(newEmployee);
            }
            else
            {
                // Fallback to storing as a pure contract/independent Artist record
                _personService.AddPerson(Artist);
            }

            return RedirectToPage("Admin");
        }
    }
}
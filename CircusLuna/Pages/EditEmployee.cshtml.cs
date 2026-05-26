using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for modifying and updating existing personnel records.
    /// Handles polymorphic type checking to correctly update individual fields 
    /// for either independent <see cref="Artist"/> or formal <see cref="Employee"/> registries.
    /// </summary>
    public class EditEmployeeModel : PageModel
    {
        private readonly PersonService _personService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditEmployeeModel"/> class.
        /// </summary>
        /// <param name="personService">The service used to retrieve and update person records.</param>
        public EditEmployeeModel(PersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Gets or sets the unique tracking identifier for the target person record being updated.
        /// </summary>
        [BindProperty]
        public string ID { get; set; }

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
        /// Only applicable when modifying an <see cref="Artist"/> entity.
        /// </summary>
        [BindProperty]
        public bool IsPermanent { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to fetch the target profile record and populate the editing form fields.
        /// Evaluates polymorphic subclasses to correctly bind base and extended properties.
        /// </summary>
        /// <param name="id">The unique lookup tracking token of the person to modify.</param>
        public void OnGet(string id)
        {
            Person person = _personService.GetById(id);

            if (person is Artist artistPerson)
            {
                ID = artistPerson.ID;
                Name = artistPerson.Name;
                Email = artistPerson.Email;
                Number = artistPerson.Number;
                Role = artistPerson.Role;
                PaymentInfo = artistPerson.PaymentInfo;
                IsPermanent = artistPerson.IsPermanent;
            }
            else if (person is Employee employeePerson)
            {
                ID = employeePerson.ID;
                Name = employeePerson.Name;
                Email = employeePerson.Email;
                Number = employeePerson.Number;
                Role = employeePerson.Role;
                PaymentInfo = employeePerson.PaymentInfo;
            }
        }

        /// <summary>
        /// Handles HTTP POST requests to persist modified profile attributes.
        /// Evaluates types early using guard clauses to block unsupported personnel hierarchies 
        /// before applying field mapping updates based on runtime types.
        /// </summary>
        /// <returns>
        /// An <see cref="NotFoundResult"/> if the data row does not exist;
        /// a <see cref="BadRequestObjectResult"/> if the type is unauthorized for this model;
        /// otherwise, a redirect route to the 'Admin' dashboard.
        /// </returns>
        public IActionResult OnPost()
        {
            Person person = _personService.GetById(ID);

            if (person == null)
            {
                return NotFound();
            }

            if (person is not Artist a && person is not Employee e)
            {
                return BadRequest("This page can only modify Employees or Artists.");
            }

            if (person is Artist artist)
            {
                artist.Name = Name;
                artist.PaymentInfo = PaymentInfo;
                artist.Number = Number;
                artist.Email = Email;
                artist.Role = Role;
                artist.IsPermanent = IsPermanent;

                _personService.UpdateEmployee(ID, artist);
            }
            else if (person is Employee employee)
            {
                employee.Name = Name;
                employee.PaymentInfo = PaymentInfo;
                employee.Number = Number;
                employee.Email = Email;
                employee.Role = Role;

                _personService.UpdateEmployee(ID, employee);
            }

            return RedirectToPage("Admin");
        }
    }
}
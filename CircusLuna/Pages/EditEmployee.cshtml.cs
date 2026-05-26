using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        /// Gets or sets the employee domain model captured from the form.
        /// Serving as the primary data source for shared personnel fields.
        /// </summary>
        [BindProperty]
        public Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the artist data model variant used to bind artist-specific 
        /// extensions such as contract permanence.
        /// </summary>
        [BindProperty]
        public Artist Artist { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to locate the profile and populate the edit form controls.
        /// Safely evaluates polymorphic types using pattern matching to assign data correctly.
        /// </summary>
        /// <param name="id">The unique identifier of the person to modify.</param>
        public void OnGet(string id)
        {
            Person person = _personService.GetById(id);

            if (person is Artist artisPerson)
            {
                // Assign to both to preserve shared fields along with distinct artist properties
                Artist = artisPerson;
                Employee = artisPerson;
            }
            else if (person is Employee employeePerson)
            {
                Employee = employeePerson;
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
            Person person = _personService.GetById(Employee.ID);

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
                
                artist.Name = Employee.Name;
                artist.PaymentInfo = Employee.PaymentInfo;
                artist.Number = Employee.Number;
                artist.Email = Employee.Email;
                artist.Role = Employee.Role;

               
                artist.IsPermanent = Artist.IsPermanent;

                _personService.UpdateEmployee(Employee.ID, artist);
            }
            else
            {
                _personService.UpdateEmployee(Employee.ID, Employee);
                
            }

            return RedirectToPage("Admin");
        }
    }
}
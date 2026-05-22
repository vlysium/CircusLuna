using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class EditEmployeeModel : PageModel
    {
        private PersonService _personService;
        
        public EditEmployeeModel(PersonService personService)
        {
            _personService = personService;
        }

        [BindProperty(SupportsGet =true)]
        public string EmployeeID { get; set; }
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public Artist Artist { get; set; }
        public void OnGet(string id)
        {
            EmployeeID = id;
            Person person = _personService.GetById(id);

            if(person is Artist artisPerson)
            {
                Artist = artisPerson;
                Employee = artisPerson;
            }
            else if(person is Employee employeePerson)
            {
                Employee = employeePerson;
            }
        }

        public IActionResult OnPost()
        {
            Person person = _personService.GetById(EmployeeID);

            if (person == null)
            {
                return NotFound();
            }

            if (person is Artist artist)
            {                
                artist.Name = Employee.Name;
                artist.PaymentInfo = Employee.PaymentInfo;
                artist.Number = Employee.Number;
                artist.Email = Employee.Email;
                artist.Role = Employee.Role;
                artist.IsPermanent = Artist.IsPermanent;

                _personService.UpdateEmployee(EmployeeID, artist);
            }
            else
            {
                _personService.UpdateEmployee(EmployeeID, Employee);
            }

            return RedirectToPage("Admin");
        }
      
    }
}

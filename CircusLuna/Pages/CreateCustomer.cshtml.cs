using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class CreateCustomerModel : PageModel
    {
        private readonly PersonService _personService;
        private List<Person> _people = new List<Person>();
        
        public CreateCustomerModel(PersonService personService)
        {
            _personService = personService;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _personService.CreatePerson(Customer);
            return RedirectToPage("Reservation");
        }
    }
}

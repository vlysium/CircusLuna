using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class AdminModel : PageModel
    {
        public List<Person> People;
        private PersonService _personService;
        [BindProperty]
        public string SearchTerm { get; set; }

        public AdminModel(PersonService personService)
        {
            _personService = personService;
        }
        public void OnGet()
        {
            People = _personService.GetAll();
        }
        public IActionResult OnPost(string id)
        {
            _personService.DeletePerson(id);
            return RedirectToPage();
        }     
    }
}

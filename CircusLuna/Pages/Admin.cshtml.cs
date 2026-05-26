using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class AdminModel : PageModel
    {        
        private PersonService _personService;
        public AdminModel(PersonService personService)
        {
            _personService = personService;
        }

        public List<Person> People;


        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }



        public void OnGet()
        {
            People = _personService.FilterAndSearch(SearchTerm);  
            
            if (!String.IsNullOrWhiteSpace(SortBy))  
            {
                People = _personService.SortByNameAZ(People,SortBy);
            }
        }


        public IActionResult OnPost(string id)
        {
            _personService.DeletePerson(id);
            return RedirectToPage();
        }     
    }
}

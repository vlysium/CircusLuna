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
            People = _personService.GetAll();
            if(!string.IsNullOrWhiteSpace(SearchTerm))   //Søgning og filtrering***************************************
            {
                List<Person> SearchList = new List<Person>();
                string searchTermClean = SearchTerm.Trim().ToLower();
                foreach (Employee e in People)
                {
                    bool nameMatches = e.Name != null && e.Name.ToLower().Contains(searchTermClean);
                    bool numberMatches = e.Number != null && e.Number.Contains(searchTermClean);
                    bool roleMatches = e.Role != null && e.Role.ToLower().Contains(searchTermClean);

                    if (nameMatches||numberMatches||roleMatches)
                    {
                        Person p =  e;
                        SearchList.Add(p);
                    }
                }               
                People = SearchList;
            }
            if (!String.IsNullOrWhiteSpace(SortBy))  //Sortering*******************************************************
            {
                List<Person> sortedPeople = new List<Person>();
                switch (SortBy)
                {
                    case "sortByNameZA":
                        sortedPeople = _personService.SortByNameAZ(People, false);
                        break;
                    case "sortByNameAZ":
                        sortedPeople = _personService.SortByNameAZ(People, true);
                        break;
                    default:
                        sortedPeople = People;
                        break;                        
                }
                People = sortedPeople;
            }
            
        }
        public IActionResult OnPost(string id)
        {
            _personService.DeletePerson(id);
            return RedirectToPage();
        }     
    }
}

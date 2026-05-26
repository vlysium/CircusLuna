using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    /// <summary>
    /// Page model for the Administration dashboard.
    /// Handles searching, sorting, and managing circus personnel records.
    /// </summary>
    public class AdminModel : PageModel
    {
        private readonly PersonService _personService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminModel"/> class.
        /// </summary>
        /// <param name="personService">The service used to manage and query personnel data.</param>
        public AdminModel(PersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Gets or sets the list of people to display on the administration page.
        /// </summary>
        public List<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the search term used to filter the people list.
        /// Automatically bound from the query string.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchFilterWord { get; set; }

        /// <summary>
        /// Gets or sets the sorting criteria (e.g., column name or direction) for the list.
        /// Automatically bound from the query string.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to populate, filter, and sort the list of people.
        /// </summary>
        public void OnGet()
        {
            People = _personService.FilterAndSearch(SearchFilterWord);

            if (!String.IsNullOrWhiteSpace(SortBy))
            {
                People = _personService.SortByNameAZ(People, SortBy);
            }
        }

        /// <summary>
        /// Handles HTTP POST requests to delete a person from the system.
        /// </summary>
        /// <param name="id">The unique identifier of the person to delete.</param>
        /// <returns>An <see cref="IActionResult"/> that redirects back to the current page.</returns>
        public IActionResult OnPost(string id)
        {
            _personService.DeletePerson(id);
            return RedirectToPage();
        }
    }
}
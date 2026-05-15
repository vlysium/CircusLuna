using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CircusLuna.Pages
{
    public class CreateArtistModel : PageModel
    {
        private readonly PersonService _pService;
        public CreateArtistModel(PersonService pService)
        {
            _pService = pService;
        }

        [BindProperty]
        public Artist Artist { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _pService.CreatePerson(Artist);
            return RedirectToPage("Index");
        }
    }
}

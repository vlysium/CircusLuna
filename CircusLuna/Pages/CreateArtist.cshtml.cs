using CircusLunaLibrary.Models;
using CircusLunaLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [BindProperty]
        public bool Employee { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Employee)
            {
                Employee newEmployee = new Employee
                {
                    ID = Artist.ID,
                    Name = Artist.Name,
                    Email = Artist.Email,
                    Number = Artist.Number,
                    Role = Artist.Role,
                    PaymentInfo = Artist.PaymentInfo
                };          
                _pService.CreatePerson(newEmployee);
            }
            else
            {
                _pService.CreatePerson(Artist);
            }
            
            return RedirectToPage("Admin");
        }
    }
}

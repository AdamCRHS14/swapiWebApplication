using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarWarsApiCSharp;
using WebApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication.Pages
{
    public class CharacterInfoModel : PageModel
    {
        public Person swChar { get; set; }
        public List<Vehicle> starships { get; set; }
        Swapi api = new Swapi();

        [BindProperty(Name = "name", SupportsGet = true)]
        public string charName { get; set; }

        public void OnGet()
        {
            try
            {
               swChar = api.SearchCharacter(charName);
                starships = api.GetVehicles(swChar);

            }
            catch
            {
                swChar = null;
                starships = null;
                RedirectToPage("/Error");
            }
            
        }

     
    }
}

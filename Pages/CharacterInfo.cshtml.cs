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
        // Attribute that links parameter and value. SupportsGet lets
        // application know this variable can be called in
        // OnGet() method
        [BindProperty(Name = "name", SupportsGet = true)]
        public string charName { get; set; }

        public Person swChar { get; set; }

        public List<Vehicle> starships { get; set; }

        public Planet homePlanet { get; set; }


        Swapi api = new Swapi();

        

        public void OnGet()
        {
            try
            {
               swChar = api.SearchCharacter(charName);
                starships = api.GetVehicles(swChar);
                GrabPlanet();

            }
            catch
            {
                swChar = null;
                starships = null;
                RedirectToPage("/Error");
            }
            
        }


        // Sets homePlanet obj with planet of specific character!
        private void GrabPlanet()
        {
            Repository<Planet> planetRepo = new Repository<Planet>();
            var idNum = api.getURLId(swChar.Homeworld);
            homePlanet = planetRepo.GetById(idNum);

        }

     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarWarsApiCSharp;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication.Model;

namespace WebApplication.Pages
{
    public class PlanetResidentModel : PageModel
    {

        Repository<Planet> planetRepo = new Repository<Planet>();
        Repository<Person> planetPersonRepo = new Repository<Person>();

        public ICollection<string> PlanetResidentNames { get; set; }

        public ICollection<Planet> AllPlanets { get; set; }

        Swapi api = new Swapi();

        public void OnGet()
        {

        }

        private void PopulatePlanets()
        {
            // TODO Get all 61 Planets
            AllPlanets = planetRepo.GetEntities(1, 60);
        }

        //TODO: Make function to grab names add to cellection.

        
        public void AddResidentNames(Planet planet)
        {
            //TODO: Clear Resident collection out and add name to string collection
            if (planet.Residents != null)
            {
                foreach (var link in planet.Residents)
                {
                    int tempUrlID = api.getURLId(link);
                    var resident = planetPersonRepo.GetById(tempUrlID);
                    PlanetResidentNames.Add(resident.Name);
                }
            }
            else
            {
                planet.Residents.Clear();
                planet.Residents.Add("None");
            }
        }
    }
}

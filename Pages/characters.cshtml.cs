using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StarWarsApiCSharp;
using WebApplication.Model;

namespace WebApplication.Pages
{
    public class charactersModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string pick { get; set; } = "Name";

        public string[] Options = { "Name", "Height", "Mass" };

        public List<Person> sortedList { get; set; }  // May not need.

        public Swapi api = new Swapi();

        bool ran = false;


        public void OnGet()
        {
            //ICollection<Person> sorted;
            if (api.swCharList == null)
            {
                api.swCharList = api.GetPeople();   
               
            }
            sortedList = api.swCharList;


            DisplayChoiceOnScreen();

        }







        private void DisplayChoiceOnScreen()
        {
            Console.WriteLine(pick);
            switch (pick)
            {
                case "Height":
                    api.swCharList.Sort((x, y) => x.Height.CompareTo(y.Height));
                    break;

                case "Mass":
                    api.swCharList.Sort((x, y) => x.Mass.CompareTo(y.Mass));
                    break;

                default:
                    api.swCharList.Sort((x, y) => x.Name.CompareTo(y.Name));
                    break;
            }

        }



    }
}
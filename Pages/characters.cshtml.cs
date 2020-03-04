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
        [BindProperty]
        public string pick { get; set; } = "Name";

        public string[] Options = { "Name", "Height", "Mass" };

        Swapi api = new Swapi();


        public void OnGet()
        {
            //ICollection<Person> sorted;
            //switch (pick)
            //{
            //    case "Height":
            //        sorted.Add(api.swCharList.OrderBy(x => x.Height);
            //        api.swCharList = sorted;
            //
            
        }

    }
}

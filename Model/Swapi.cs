using System;
using System.Collections.Generic;
using System.Linq;
using StarWarsApiCSharp;
using WebApplication.Pages;

namespace WebApplication.Model
{
    public class Swapi
    {
        
        Repository<Person> peopleRepo = new Repository<Person>();

        public ICollection<Person> swCharList { get; set; }

        Person character = null;


        public Swapi()
        {
           
        }


        // Method to grab all 50 Person objects from https://swapi.co/
        public ICollection<Person> GetPeople() 
        {
            return peopleRepo.GetEntities(1, 50);
        }

        // Gets ID parameter from all urls used in this application
        public int getURLId(string urlAddress)
        {
            string[] url = urlAddress.Split("/");
            return Int32.Parse(url[^2]);
        }


        // Method that searches through collection of characters to see if character exists.
        public Person SearchCharacter(string charName)
        {            

            if (swCharList != null)
            {
                foreach (var peep in swCharList)
                {
                    if (peep.Name.ToLower().Contains(charName.ToLower()))
                    {
                        character = peep;
                        goto LoopExit; // Goes back to specified label
                    }

                }

            LoopExit: // Creates label for loop to exit to.
                return character;
            }
            else
            {
                // Ensures list being iterated gets populated,
                // then runs this method.
                swCharList = this.GetPeople();
               return SearchCharacter(charName);
            }
           
        }


        // Method used to return collection of vehicle objects instead of URLs.
        public List<Vehicle> GetVehicles(Person swCharName)
        {
            List<int> urlID = new List<int>();
            List<Vehicle> ships = new List<Vehicle>();
            var vehicleRepo = new Repository<Vehicle>();

            if(swCharName.Vehicles != null)
            {
                foreach (var link in swCharName.Vehicles)
                {
                    urlID.Add(getURLId(link));

                }
                foreach (var id in urlID)
                {
                    var vehicle = vehicleRepo.GetById(id);
                    Console.WriteLine(vehicle.Name + "\n" + vehicle.Model);
                    ships.Add(vehicle);

                }
            }
            else
            {
                ships = null;
            }
            
            return ships;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Synerscope.Models;

namespace Synerscope.DataAccess
{
    public class HobbiesInit : System.Data.Entity.DropCreateDatabaseIfModelChanges<HobbiesContext>
    {
        //Arash: all DONE
        protected override void Seed(HobbiesContext context)
        {
            var people = new List<Person>
            {
                new Person{ FirstName="Tahsin", LastName="Ettefagh"},
                new Person{ FirstName="Jasmine", LastName="Ettefagh"},
                new Person{ FirstName="Sarah", LastName="Sezi"},
                new Person{ FirstName="Sayeh", LastName="Roshan"},
                new Person{ FirstName="Ewa", LastName="krymer"},
                new Person{ FirstName="Alessio", LastName="Di Giovanni"}
            };
            people.ForEach(s => context.People.Add(s));
            context.SaveChanges();

            var hobbies = new List<Hobby>
            {
            new Hobby{ PersonID=1,HobbyID=1050,Name="biking"},
            new Hobby{ PersonID=1,HobbyID=4022,Name="hiking"},
            new Hobby{ PersonID=1,HobbyID=4041,Name="dancing"},
            new Hobby{ PersonID=2,HobbyID=1045,Name="biking"},
            new Hobby{ PersonID=2,HobbyID=3141,Name="coding"},
            new Hobby{ PersonID=2,HobbyID=2021,Name="cooking"},
            new Hobby{ PersonID=3,HobbyID=1050,Name="driving"},
            new Hobby{ PersonID=4,HobbyID=1050,Name="reading"},
            new Hobby{ PersonID=4,HobbyID=4022,Name="walking"},
            new Hobby{ PersonID=5,HobbyID=4041,Name="gym"},
            new Hobby{ PersonID=6,HobbyID=1045,Name="music"}
            };
            hobbies.ForEach(s => context.Hobbies.Add(s));
            context.SaveChanges();
        }
    }
}
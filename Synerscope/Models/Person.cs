using System;
using System.Collections.Generic;


namespace Synerscope.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Introduction the relations to EF
        public virtual ICollection<Hobby> Synerscope { get; set; }
    }
}
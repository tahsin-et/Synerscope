using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Synerscope.Models
{
    public class Hobby
    {
        public int HobbyID { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
    }
}
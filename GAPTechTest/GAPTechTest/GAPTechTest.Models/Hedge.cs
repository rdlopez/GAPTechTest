using System.Collections.Generic;

namespace GAPTechTest.Models
{
    public class Hedge
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Percentage { get; set; }

        public virtual List<Policy> Policies { get; set;}
    }
}
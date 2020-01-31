using GAPTechTest.Models;
using System.Data.Entity;

namespace GAPTechTest.DataAccess
{
    public class GAPTechContext : DbContext
    {
        public GAPTechContext() : base("name=GAPTechTestDB")
        {
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Policy> Policies { get; set; }

        public DbSet<Hedge> Hedges { get; set; }
    }
}

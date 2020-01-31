namespace GAPTechTest.DataAccess.Migrations
{
    using GAPTechTest.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GAPTechContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GAPTechContext context)
        {
            var hedges = new Hedge[]
            {
                new Hedge{ Name = "Terremoto", Percentage = 50 },
                new Hedge{ Name = "Incendio", Percentage = 30 },
                new Hedge{ Name = "Robo", Percentage = 10 },
                new Hedge{ Name = "Pérdida", Percentage = 5 }
            };

            var policies = new Policy[]
            {
                new Policy
                    {
                        Name = "Hogar Seguro - Full", Description = "Cuida tu hogar - Full", StartDate = DateTime.Now, Period = 12, Price = 100000, RiskType = ERiskType.Alto, Hedge = hedges[0]
                    },
                new Policy
                    {
                        Name = "Hogar Seguro - Parcial", Description = "Cuida tu hogar - Parcial", StartDate = DateTime.Now, Period = 12, Price = 50000, RiskType = ERiskType.Medio, Hedge = hedges[1]
                    },
                new Policy
                    {
                        Name = "Libre Terremotos", Description = "Cuidamos de ti y tus seres queridos", StartDate = DateTime.Now, Period = 6, Price = 48000, RiskType = ERiskType.Bajo, Hedge = hedges[0]
                    },
                new Policy
                    {
                        Name = "Activos", Description = "Por que tus cosas son tu esfuerzo, las cuidamos de cualquier robo", StartDate = DateTime.Now, Period = 12, Price = 10000, RiskType = ERiskType.Bajo, Hedge = hedges[3]
                    }
            };

            context.Hedges.AddOrUpdate<Hedge>(hedges);
            context.Policies.AddOrUpdate<Policy>(policies);
            context.SaveChanges();
        }
    }
}
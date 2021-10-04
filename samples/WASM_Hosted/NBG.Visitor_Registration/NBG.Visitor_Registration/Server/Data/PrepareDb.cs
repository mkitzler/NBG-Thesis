using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NBG.Visitor_Registration.Server.ModelContexts;
using NBG.Visitor_Registration.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBG.Visitor_Registration.Server.Data
{
    public static class PrepareDb
    {
        public static void PreparePopulation(IApplicationBuilder application)
        {
            using(var serviceScope = application.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<VisitorContext>());
            }
        }

        private static void SeedData(VisitorContext context)
        {
            if (!context.Visitors.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Visitors.AddRange(
                    new Visitor()
                    {
                        FirstName = "Herwig",
                        LastName = "Macho",
                        Email = "0676 9988777",
                        Company = "HTL Krems"
                    },
                    new Visitor()
                    {
                        FirstName = "Markus",
                        LastName = "Brunner",
                        Email = "0676 1122333",
                        Company = "HTL Krems"
                    },
                    new Visitor()
                    {
                        FirstName = "Karin",
                        LastName = "Knotzer",
                        Email = "0676 4455666",
                        Company = "MKM Stift Zwettl"
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> There already is data.");
            }

        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using VisitorService.ModelContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisitorService.Models;

namespace VisitorService.Data
{
    public static class PrepareDb
    {
        public static void PreparePopulation(IApplicationBuilder application)
        {
            using(var serviceScope = application.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Visitors.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Visitors.AddRange(
                    new Visitor()
                    {
                        FirstName = "Herwig",
                        LastName = "Macho",
                        Email = "h.macho@htlkrems.at",
                        PhoneNumber = "0676 9988777",
                        Company = "HTL Krems"
                    },
                    new Visitor()
                    {
                        FirstName = "Markus",
                        LastName = "Brunner",
                        Email = "m.brunner@htlkrems.at",
                        PhoneNumber = "0676 1122333",
                        Company = "HTL Krems"
                    },
                    new Visitor()
                    {
                        FirstName = "Karin",
                        LastName = "Knotzer",
                        PhoneNumber = "0676 4455666",
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

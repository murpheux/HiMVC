using HiMVC.Models;
using HiMVC.Models.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {

                if (context.Students.Any())
                {
                    return;   // DB has been seeded
                }

                context.Students.AddRange(
                    new Student()
                    {
                        Name = "Clement Onawole",
                        Age = 25,
                        Sex = "M"
                    },
                    new Student()
                    {
                        Name = "Amina Gboro",
                        Age = 23,
                        Sex = "F"
                    },
                    new Student()
                    {
                        Name = "Seun Arije",
                        Age = 45,
                        Sex = "M"
                    });

                context.SaveChanges();
            }
        }
    }
}

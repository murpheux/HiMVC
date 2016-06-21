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
                    new Student() { FirstName = "Clement", LastName = "Onawole", Email = "dapo.onawole@gmail.com", DateOfBirth = new DateTime(1975, 12, 28), Sex = Sex.Male, Nationality = "Pakistan", GPA = 3.5f },
                    new Student() { FirstName = "Amina", LastName = "Gboro", Email = "amina.gboro@gmail.com", DateOfBirth = new DateTime(1974, 06, 02), Sex = Sex.Female, Nationality = "Bahrain", GPA = 2.7f },
                    new Student() { FirstName = "Seun", LastName = "Arije", Email = "seun.arije@yahoo.com", DateOfBirth = new DateTime(1972, 8, 16), Sex = Sex.Male, Nationality = "India", GPA = 3.2f },
                    new Student() { FirstName = "Amena", LastName = "Umeana", Email = "amena@yahoo.com", DateOfBirth = new DateTime(1972, 8, 16), Sex = Sex.Female, Nationality = "Pakistan", GPA = 4.2f },
                    new Student() { FirstName = "Lola", LastName = "Popoola", Email = "lola.popoola@yahoo.com", DateOfBirth = new DateTime(1972, 8, 16), Sex = Sex.Female, Nationality = "Germany", GPA = 2.2f },
                    new Student() { FirstName = "Sola", LastName = "Sobande", Email = "sola.soband@gmail.com", DateOfBirth = new DateTime(1972, 8, 16), Sex = Sex.Male, Nationality = "Pakistan", GPA = 1.8f },
                    new Student() { FirstName = "Jide", LastName = "Ariyibi", Email = "jariyibi@email.com", DateOfBirth = new DateTime(1972, 8, 16), Sex = Sex.Female, Nationality = "India", GPA = 3.2f },
                    new Student() { FirstName = "Bukola", LastName = "George", Email = "b.george@yahoo.com", DateOfBirth = new DateTime(1972, 8, 16), Sex = Sex.Female, Nationality = "Pakistan", GPA = 4.5f },
                    new Student() { FirstName = "Seun", LastName = "Opanuga", Email = "seun.opanuga@yahoo.com", DateOfBirth = new DateTime(1972, 8, 16), Sex = Sex.Male, Nationality = "France", GPA = 3.4f });

                context.SaveChanges();
            }
        }
    }
}

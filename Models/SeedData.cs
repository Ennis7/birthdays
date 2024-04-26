using Birthdays.Data;
using Microsoft.EntityFrameworkCore;

namespace Birthdays.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BirthdaysContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<BirthdaysContext>>()))
            {
                if (context == null || context.Birthday == null)
                {
                    throw new ArgumentNullException("Null BirthdaysContext");
                }

                //Look for any birthdays
                if (context.Birthday.Any())
                { 
                    return; // DB has been seeded
                }

                context.Birthday.AddRange(
                    new Birthday
                    {
                        FirstName = "Dick",
                        MiddleName = "Van",
                        LastName = "Dyke",
                        Age = 98,
                        DOB = DateTime.Parse("1925-12-13")
                    },
                    new Birthday
                    {
                        FirstName = "Taylor",
                        MiddleName = "Alison",
                        LastName = "Swift",
                        Age = 34,
                        DOB = DateTime.Parse("1925-12-13")
                    },
                    new Birthday
                    {
                        FirstName = "Big",
                        MiddleName = "Yellow",
                        LastName = "Bird",
                        Age = 55,
                        DOB = DateTime.Parse("1969-03-20")
                    },
                    new Birthday
                    {
                        FirstName = "Thomas",
                        MiddleName = "The",
                        LastName = "Train",
                        Age = 68,
                        DOB = DateTime.Parse("1945-05-12")
                    },
                    new Birthday
                    {
                        FirstName = "Neil",
                        MiddleName = "deGrasse",
                        LastName = "Tyson",
                        Age = 65,
                        DOB = DateTime.Parse("1958-10-05")
                    }
                    );
                    context.SaveChanges();
            }
        }
    }
}

using Library.Models;
using System.Linq;
using System;

namespace Library.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(UserContext context)
        {
            context.Database.EnsureCreated();

            // Look for any User
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }

            var User = new Users[]
            {
                new Users{ID=1, Name="To Kill a Mockingbird", Author="Harper Lee", PageCount = 296, Year = 1960, Read = true},
                new Users{ID=2, Name="Ulysses", Author="James Joyce", PageCount = 730 ,Year = 1922, Read = true},
                new Users{ID=3, Name="The Great Gatsby", Author="F. Scott Fitzgerald", PageCount = 218, Year= 1925, Read = false},
                new Users{ID=4, Name="Moby Dick", Author="Herman Melville", PageCount = 585,Year = 1851, Read = false},
                new Users{ID=5, Name="Alice's Adventures in Wonderland", Author="Lewis Carroll", PageCount = 192, Year = 1865, Read = true},
            };

            foreach (Users u in User)
            {
                context.User.Add(u);
            }
            context.SaveChanges();
        }
    }
}

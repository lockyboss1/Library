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
                new Users{ID=1, Name="My Life in Red and White: My Autobiography", Author="Arsene Wenger", ISBN = "9781474618243" ,Read = true},
                new Users{ID=2, Name="Ulysses", Author="James Joyce", ISBN = "9780192834645" ,Read = true},
                new Users{ID=3, Name="The Great Gatsby", Author="F. Scott Fitzgerald", ISBN = "9780333791035" ,Read = false},
                new Users{ID=4, Name="Moby Dick", Author="Herman Melville",ISBN = "9788540504493" ,Read = false},
                new Users{ID=5, Name="Alice's Adventures in Wonderland", Author="Lewis Carroll", ISBN = "9780194227230" ,Read = true},
            };

            foreach (Users u in User)
            {
                context.User.Add(u);
            }
            context.SaveChanges();
        }
    }
}

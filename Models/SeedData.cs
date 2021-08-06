using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ELibrary.Data;
using System;
using System.Linq;

namespace ELibrary.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ELibraryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ELibraryContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book

                    {
                        Title = "Java : the complete reference ",
                        Author = "Schildt, Herbert.",
                        Format = "Book",
                        Language = "English",
                        PublishDate = DateTime.Parse("1989-2-12"),
                        Edition = "8th",
                        Holding = true,
                        Description=" ",
                        HoldingDate = DateTime.Parse("1989-2-12"),
                        DueDate = DateTime.Parse("1989-2-12"),
                        StudentId = 123
                    }

                    //new Book
                    //{
                    //    Title = "Ghostbusters ",
                    //    ReleaseDate = DateTime.Parse("1984-3-13"),
                    //    Genre = "Comedy",
                    //    Price = 8.99M
                    //},

                    //new Book
                    //{
                    //    Title = "Ghostbusters 2",
                    //    ReleaseDate = DateTime.Parse("1986-2-23"),
                    //    Genre = "Comedy",
                    //    Price = 9.99M
                    //},

                    //new Book
                    //{
                    //    Title = "Rio Bravo",
                    //    ReleaseDate = DateTime.Parse("1959-4-15"),
                    //    Genre = "Western",
                    //    Price = 3.99M
                    //}
                );
                context.SaveChanges();
            }
        }
    }
}
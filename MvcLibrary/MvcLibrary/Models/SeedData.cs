using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcLibrary.Data;
using System;
using System.Linq;

namespace MvcLibrary.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcLibraryContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcLibraryContext>>()))
        {
            // Look for any movies.
            if (context.Library.Any())
            {
                return;   // DB has been seeded
            }
            context.Library.AddRange(
                new Library
                {
                    Title = "Kambing Jantan",
                    Author = "Raditya Dika",
                    Publisher = "Gramedia",
                    ReleaseDate = DateTime.Parse("2003-2-12"),
                    Genre = "Comedy",
                    Price = 15
                }
            );
            context.SaveChanges();
        }
    }
}
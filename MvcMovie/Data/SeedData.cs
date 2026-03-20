using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>());

        // Look for any movies.
        if (context.Movie.Any())
        {
            return;   // DB has been seeded
        }

        context.Movie.AddRange(
            new Movie
            {
                Title = "The Matrix",
                ReleaseDate = DateTime.Parse("1999-03-31"),
                Genre = "Sci-Fi",
                Price = 9.99M
            },
            new Movie
            {
                Title = "Inception",
                ReleaseDate = DateTime.Parse("2010-07-16"),
                Genre = "Action",
                Price = 12.99M
            },
            new Movie
            {
                Title = "The Lion King",
                ReleaseDate = DateTime.Parse("1994-06-24"),
                Genre = "Animation",
                Price = 7.99M
            }
        );

        context.SaveChanges();
    }
}
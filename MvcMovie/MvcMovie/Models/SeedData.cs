using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;

namespace MvcMovie.Models
{

    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                       serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                //look for any movies
                if (context.Movie.Any()) return; //database has been seeded


                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Ephraim's Rescue",
                        ReleaseDate = DateTime.Parse("2013-5-31"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 15.99M,
                        PhotoPath = "f5d188ec-ce96-4ced-a268-8d74de5a6bbdEmphraimsRescue.jpg"

                    },
                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = "Documentary",
                        Rating = "PG",
                        Price = 10.57M,
                        PhotoPath = "6a3250fc-0588-4cb7-b1bd-3fc9924d90bcMeetTheMormons.jpg"
                    },
                    new Movie
                    {
                        Title = "The RM",
                        ReleaseDate = DateTime.Parse("2015-3-20"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 19.64M,
                        PhotoPath = "a3bbf25b-9b1c-42bf-92e5-5aad5a64a197TheRM.jpg"
                    },
                    new Movie
                    {
                        Title = "The Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("2001-12-14"),
                        Genre = "Drama",
                        Rating = "PG",
                        Price = 6.71M,
                        PhotoPath = "5095e20c-da4b-4895-955a-14c3cf624decTheOtherSideOfHeaven.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
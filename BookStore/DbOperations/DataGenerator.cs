using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author
                    {
                        Name = "Yasemin",
                        Surname = "Türk",
                        Birthday = new DateTime(1996, 7, 21)
                    },
                    new Author
                    {
                        Name = "Ebru",
                        Surname = "Korkmaz",
                        Birthday = new DateTime(2001, 4, 15)
                    },
                    new Author
                    {
                        Name = "Ahmet",
                        Surname = "Erkan",
                        Birthday = new DateTime(1998, 3, 18)
                    }
                );

                context.Genres.AddRange(
                    new Genre()
                    {
                        Name="Personal Growth"
                    },
                    new Genre()
                    {
                        Name = "Science Fiction"
                    },
                    new Genre()
                    {
                        Name = "Romance"
                    }
                );

                context.Books.AddRange(
                    new Book()
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, //Personal Growth
                        PageCount = 222,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book()
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, //Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book()
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2, //Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 21)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}

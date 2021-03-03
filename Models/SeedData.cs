using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            CharityDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<CharityDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate(); // get error here database already exist, choose different name
            }
            //this is where the seed data is, you can add and update info there in case there is nothing in the database.
            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        Isbn = "978-0451419439",
                        Category = "Fiction,Classic",
                        PageNumbers = 1488,
                        Price = 9.95,
                    },
                    new Book
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        Isbn = "978-0743270755",
                        Category = "Non-Fiction, Biography",
                        PageNumbers = 944,
                        Price = 14.58
                    },
                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        Isbn = "978-0553384611",
                        Category = "Non-Fiction, Biography",
                        PageNumbers = 832,
                        Price = 21.54
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        Isbn = "978-0812981254",
                        Category = "Non-Fiction, Biography",
                        PageNumbers = 864,
                        Price = 11.61
                    },
                    new Book
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        Isbn = "978-0812974492",
                        Category = "Non-Fiction, Historical",
                        PageNumbers = 528,
                        Price = 13.33
                    },
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        Isbn = "978-0804171281",
                        Category = "Fiction, Historical Fiction",
                        PageNumbers = 288,
                        Price = 15.95
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455586691",
                        Category = "Non-Fiction, Self-Help",
                        PageNumbers = 304,
                        Price = 14.99
                    },
                    new Book
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455523023",
                        Category = "Non-Fiction, Self-Help",
                        PageNumbers = 240,
                        Price = 21.66
                    },
                    new Book
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        Isbn = "978-1591847984",
                        Category = "Non-Fiction, Business",
                        PageNumbers = 400,
                        Price = 29.16
                    },
                    new Book
                    {
                        Title = "Sycamore Row",
                        Author = "John Grisham",
                        Publisher = "Bantam",
                        Isbn = "978-0553393613",
                        Category = "Fiction, Thrillers",
                        PageNumbers = 642,
                        Price = 15.03
                    },
                    new Book
                    {
                        Title = "El Libro de Mormon",
                        Author = "Los Profetas",
                        Publisher = "The Church of Jesus Christ of Latter Day Saints",
                        Isbn = "978-0143105534",
                        Category = "Religion",
                        PageNumbers = 642,
                        Price = 3.10
                    },
                    new Book
                    {
                        Title = "Outwitting the Devil",
                        Author = "Napoleon Hill",
                        Publisher = "The Napoleon Hill Foundation",
                        Isbn = "978-1402784538",
                        Category = "Self-Help",
                        PageNumbers = 493,
                        Price = 12.79
                    },
                    new Book
                    {
                        Title = "How to Win Friends and Influence People",
                        Author = "Dale Carnegie",
                        Publisher = "Simon & Schuster",
                        Isbn = "978-1442344815",
                        Category = "Self-Help",
                        PageNumbers = 272,
                        Price = 11.85
                    }

                );

                context.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CityLibraryTestWork.Models;

namespace CityLibraryTestWork.Repository
{
    public class CityLibraryDbInitialazer : DropCreateDatabaseAlways<LibraryDbContext>
    {
        protected override void Seed(LibraryDbContext context)
        {
            context.Books.AddRange(new List<Book>
                    {
                        new Book
                        {
                            Title = "Pride and Prejudice",
                            Autor = new Autor
                            {
                                FirstName = "Jane",
                                SecondName = "Austen"
                            },
                            Serie = new Serie { SerieName = "Enriched classic" },
                            Publisher = new Publisher { PublisherName = "Simon and Schuster" }
                        },
                        new Book
                        {
                            Title = "Thumbelina",
                            Autor = new Autor
                            {
                                FirstName = "Hans Christian",
                                SecondName = "Andersen"
                            },
                            Serie = new Serie { SerieName = "Illustrated fairytales" },
                            Publisher = new Publisher { PublisherName = "Scandinavia Publishing House" }
                        },
                        new Book
                        {
                            Title = "Frankenstein",
                            Autor = new Autor
                            {
                                FirstName = "Mary ",
                                SecondName = "Wollstonecraft Shelley"
                            },
                            Serie = new Serie { SerieName = "Spotlight Edition" },
                            Publisher = new Publisher { PublisherName = "Prestwick House Inc" }
                        }
                    }
                );
        }

    }
}
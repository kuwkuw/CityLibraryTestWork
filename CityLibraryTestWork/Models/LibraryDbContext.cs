using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CityLibraryTestWork.Repository;

namespace CityLibraryTestWork.Models
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() : base("name = LibraryBdTest")
        {
            Database.SetInitializer(new CityLibraryDbInitialazer());
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}

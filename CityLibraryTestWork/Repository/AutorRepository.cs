using System;
using System.Data.Entity;
using System.Linq;
using CityLibraryTestWork.Models;

namespace CityLibraryTestWork.Repository
{
    public class AutorRepository :BaseRepository<Autor>
    {
        public AutorRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
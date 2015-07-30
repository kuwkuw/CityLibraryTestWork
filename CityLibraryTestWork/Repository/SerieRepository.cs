using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityLibraryTestWork.Models;

namespace CityLibraryTestWork.Repository
{
    public class SerieRepository: BaseRepository<Serie>
    {
        public SerieRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
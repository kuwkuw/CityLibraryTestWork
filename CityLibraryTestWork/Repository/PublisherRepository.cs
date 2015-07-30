using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityLibraryTestWork.Models;

namespace CityLibraryTestWork.Repository
{
    public class PublisherRepository : BaseRepository<Publisher>
    {
        public PublisherRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
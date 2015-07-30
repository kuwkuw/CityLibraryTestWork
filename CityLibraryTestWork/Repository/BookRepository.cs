using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityLibraryTestWork.Models;

namespace CityLibraryTestWork.Repository
{
    public class BookRepository: BaseRepository<Book>
    {
        public BookRepository(LibraryDbContext context)
            : base(context)
        {

        }
    }
}
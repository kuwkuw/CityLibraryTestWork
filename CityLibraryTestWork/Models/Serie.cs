using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryTestWork.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
        public string SerieName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}

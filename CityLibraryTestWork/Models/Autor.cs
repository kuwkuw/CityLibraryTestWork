using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryTestWork.Models
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<Book> Books { get; set; }        
    }
}

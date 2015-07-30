using System.ComponentModel.DataAnnotations;

namespace CityLibraryTestWork.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        //public virtual int AutorId { get; set; }
        //public virtual int SerieId { get; set; }
        //public virtual int PublisherId { get; set; }

        public virtual Autor Autor { get; set; }
        public virtual Serie Serie { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}

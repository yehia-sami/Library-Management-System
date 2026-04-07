using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SummerProject.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }


        public List<Book> Books { get; set; } = new List<Book>();
    }
}

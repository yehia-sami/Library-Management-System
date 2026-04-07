using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SummerProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(40)]
        public string Name { get; set; }

        public List<BookCategories> BookCategories { get; set; } = new List<BookCategories>();
   

    }
}

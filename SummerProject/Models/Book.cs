using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
//using SummerProject.Models.Validators;
namespace SummerProject.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required"),StringLength(120)]
        [Remote("CheckTitle", "Books", AdditionalFields = "Id", ErrorMessage = "Title already exists")]
        [TitleStartsWithCapital]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public List<BookCategories> BookCategories { get; set; } = new List<BookCategories>();

        public List<Loan> Loans { get; set; } = new List<Loan>();
    }
}

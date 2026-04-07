using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SummerProject.Models
{
    public class Loan
    {
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.UtcNow;
        public DateTime ReturnDate { get; set; }
      

    }
}

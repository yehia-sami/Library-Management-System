using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace SummerProject.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<Loan> Loans { get; set; } = new List<Loan>();
    }
}

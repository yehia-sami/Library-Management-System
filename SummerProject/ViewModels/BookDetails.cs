using SummerProject.Models;
using System.Collections.Generic;
namespace SummerProject.ViewModels
{
    public class BookDetails
    {
        public Book Book { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public string PageTitle { get; set; }
        public int TotalBooksByAuthor { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using SummerProject.Models;

namespace SummerProject.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);

        bool TitleExists(string title,int id);

         List<Category> GetAllCategories();
         List<Author> GetAllAuthors();


        
    }
}

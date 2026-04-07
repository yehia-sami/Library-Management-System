using SummerProject.Models;
using System.Collections.Generic;

namespace SummerProject.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author GetById(int id);
        void Add(Author author);
        void Update(Author author);
        void Delete(int id);
    }
}

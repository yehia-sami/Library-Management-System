using SummerProject.Models;
using System.Collections.Generic;

namespace SummerProject.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category, int[] bookIds);
        void Update(Category category, int[] bookIds);
        void Delete(int id);
    }
}

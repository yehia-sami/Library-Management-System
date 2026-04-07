using Microsoft.EntityFrameworkCore;
using SummerProject.Data;
using SummerProject.Models;

namespace SummerProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Appdata _context;

        public CategoryRepository(Appdata context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                .ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories
                .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                .FirstOrDefault(c => c.Id == id)!;
        }

        public void Add(Category category, int[] bookIds)
        {
            foreach (var bId in bookIds)
            {
                category.BookCategories.Add(new BookCategories { BookId = bId });
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category, int[] bookIds)
        {
            var existing = _context.Categories
                .Include(c => c.BookCategories)
                .FirstOrDefault(c => c.Id == category.Id);

            if (existing == null) return;

            existing.Name = category.Name;

            existing.BookCategories.Clear();
            foreach (var bId in bookIds)
            {
                existing.BookCategories.Add(new BookCategories { BookId = bId });
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _context.Categories
                .Include(c => c.BookCategories)
                .FirstOrDefault(c => c.Id == id);

            if (category == null) return;

            category.BookCategories.Clear(); 
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}

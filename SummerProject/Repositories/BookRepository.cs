using Microsoft.EntityFrameworkCore;
using SummerProject.Data;
using SummerProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SummerProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Appdata _context;
        public BookRepository(Appdata context)
        {
            _context = context;
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Book> GetAll()
        {
            return _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .FirstOrDefault(b => b.Id == id)!;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public bool TitleExists(string title, int id )
        {
            return _context.Books.Any(b => b.Title == title && b.Id != id);
        }

    }
}

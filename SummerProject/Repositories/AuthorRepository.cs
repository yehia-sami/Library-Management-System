using SummerProject.Data;
using SummerProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace SummerProject.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Appdata _context;

        public AuthorRepository(Appdata context)
        {
            _context = context;
        }

        public List<Author> GetAll()
        {
            // Include related books
            return _context.Authors
                .Include(a => a.Books)
                .ToList();
        }

        public Author GetById(int id)
        {
            return _context.Authors
                .Include(a => a.Books)
                .FirstOrDefault(a => a.Id == id)!;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void Update(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}

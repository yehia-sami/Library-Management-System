using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerProject.Models;
using SummerProject.Repositories;
using System.Linq;

namespace SummerProject.Controllers
{
    
    public class BooksController : Controller
    {
        private readonly IBookRepository _repo;

        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

      
        public IActionResult Index()
        {
            var books = _repo.GetAll();
            return View(books);
        }

       
        public IActionResult BookListPartial()
        {
            var books = _repo.GetAll();
            return PartialView("_BookList", books);
        }

     
        public IActionResult Details(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            ViewBag.Authors = _repo.GetAllAuthors();
            ViewBag.Categories = _repo.GetAllCategories();
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book, int[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _repo.GetAllAuthors();
                ViewBag.Categories = _repo.GetAllCategories();
                return View(book);
            }

            book.BookCategories = selectedCategories
                .Select(cId => new BookCategories { BookId = book.Id, CategoryId = cId })
                .ToList();

            _repo.Add(book);
            TempData["Success message"] = $"{book.Title} created successfully.";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();

            ViewBag.Authors = _repo.GetAllAuthors();
            ViewBag.Categories = _repo.GetAllCategories();
            ViewBag.SelectedCategories = book.BookCategories.Select(bc => bc.CategoryId).ToArray();

            return View(book);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book, int[] selectedCategories)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = _repo.GetAllAuthors();
                ViewBag.Categories = _repo.GetAllCategories();
                return View(book);
            }

            var existingBook = _repo.GetById(book.Id);
            if (existingBook == null) return NotFound();

            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;

            existingBook.BookCategories.Clear();
            foreach (var cId in selectedCategories)
            {
                existingBook.BookCategories.Add(new BookCategories { BookId = book.Id, CategoryId = cId });
            }

            _repo.Update(existingBook);
            TempData["Success message"] = $"{book.Title} updated successfully.";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var book = _repo.GetById(id);
            if (book == null) return NotFound();
            return View(book);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            _repo.Delete(id);
            TempData["Success message"] = "Book deleted successfully.";
            return RedirectToAction("Index");
        }
        
     
        public JsonResult CheckTitle(string title, int id)
        {
            bool exists = _repo.TitleExists(title, id);
            return Json(!exists);
        }

    }
}

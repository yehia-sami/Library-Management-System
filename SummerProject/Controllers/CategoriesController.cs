using Microsoft.AspNetCore.Mvc;
using SummerProject.Models;
using SummerProject.Repositories;

namespace SummerProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repo;
        private readonly IBookRepository _bookRepo;

        public CategoriesController(ICategoryRepository repo, IBookRepository bookRepo)
        {
            _repo = repo;
            _bookRepo = bookRepo;
        }

    
        public IActionResult Index()
        {
            var categories = _repo.GetAll();
            return View(categories);
        }

       
        public IActionResult Details(int id)
        {
            var category = _repo.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

     
        public IActionResult Create()
        {
            ViewBag.Books = _bookRepo.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category, int[] selectedBooks)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Books = _bookRepo.GetAll();
                return View(category);
            }

            _repo.Add(category, selectedBooks);
            TempData["SuccessMessage"] = $"{category.Name} category created successfully!";
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Edit(int id)
        {
            var category = _repo.GetById(id);
            if (category == null) return NotFound();

            ViewBag.Books = _bookRepo.GetAll();
            ViewBag.SelectedBooks = category.BookCategories.Select(bc => bc.BookId).ToArray();
            return View(category);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category, int[] selectedBooks)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Books = _bookRepo.GetAll();
                ViewBag.SelectedBooks = selectedBooks;
                return View(category);
            }

            _repo.Update(category, selectedBooks);
            TempData["SuccessMessage"] = $"{category.Name} category updated successfully!";
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Delete(int id)
        {
            var category = _repo.GetById(id);
            if (category == null) return NotFound();
            return View(category);
        }

      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            TempData["SuccessMessage"] = $"Category deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}

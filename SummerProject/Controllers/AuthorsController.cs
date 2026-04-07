using Microsoft.AspNetCore.Mvc;
using SummerProject.Models;
using SummerProject.Repositories;

namespace SummerProject.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _repo;

        public AuthorsController(IAuthorRepository repo)
        {
            _repo = repo;
        }

   
        public IActionResult Index()
        {
            var authors = _repo.GetAll();
            return View(authors);
        }

    
        public IActionResult Details(int id)
        {
            var author = _repo.GetById(id);
            if (author == null) return NotFound();
            return View(author);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Author author)
        {
            if (!ModelState.IsValid) return View(author);

            _repo.Add(author);
            TempData["SuccessMessage"] = $"{author.Name} created successfully!";
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Edit(int id)
        {
            var author = _repo.GetById(id);
            if (author == null) return NotFound();
            return View(author);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Author author)
        {
            if (!ModelState.IsValid) return View(author);

            _repo.Update(author);
            TempData["SuccessMessage"] = $"{author.Name} updated successfully!";
            return RedirectToAction(nameof(Index));
        }

      
        public IActionResult Delete(int id)
        {
            var author = _repo.GetById(id);
            if (author == null) return NotFound();
            return View(author);
        }

     
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            TempData["SuccessMessage"] = $"Author deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}

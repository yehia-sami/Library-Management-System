using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerProject.Data;
using SummerProject.Models;
using System.Linq;

namespace SummerProject.Controllers
{
    [Authorize]
    public class LoansController : Controller
    {
        private readonly Appdata _context;

        public LoansController(Appdata context)
        {
            _context = context;
        }

       
        public IActionResult Index()
        {
            var loans = _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Customer)
                .ToList();

            return View(loans);
        }

       
   

       
        public IActionResult Create()
        {
            ViewBag.Books = _context.Books.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.LoanDate = DateTime.UtcNow;
                _context.Loans.Add(loan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Books = _context.Books.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View(loan);
        }











    }
}

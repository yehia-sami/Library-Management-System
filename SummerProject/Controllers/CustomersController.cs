using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SummerProject.Data;
using SummerProject.Models;
using System.Linq;

namespace SummerProject.Controllers
{
	public class CustomersController : Controller
	{
		private readonly Appdata _context;

		public CustomersController(Appdata context)
		{
			_context = context;
		}


        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }





        public IActionResult Create()
		{
			return View();
		}

	
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Customer customer)
		{
			if (ModelState.IsValid)
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(customer);
		}

		
	



		

		
	
	}
}

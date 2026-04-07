using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SummerProject.Data;
using System.Threading.Tasks;
using System.Linq;

[Authorize(Roles = "Admin")]
public class AdminDashboardController : Controller
{
    private readonly Appdata _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdminDashboardController(
        Appdata context,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        
        ViewBag.TotalBooks = _context.Books.Count();
        ViewBag.TotalCategories = _context.Categories.Count();
        ViewBag.TotalCustomers = _context.Customers.Count();
        ViewBag.TotalLoans = _context.Loans.Count();

      
        var users = _userManager.Users.ToList();
        ViewBag.CurrentUserEmail = User.Identity.Name;
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserToRole(string userId, string role)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null || !await _roleManager.RoleExistsAsync(role))
            return RedirectToAction("Index");

       
        var currentRoles = await _userManager.GetRolesAsync(user);
        await _userManager.RemoveFromRolesAsync(user, currentRoles);

        
        await _userManager.AddToRoleAsync(user, role);
        return RedirectToAction("Index");
    }
}

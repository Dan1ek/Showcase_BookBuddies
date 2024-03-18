using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Showcase_BookBuddies.Business.Entities;
using Showcase_BookBuddies.Data;
using Showcase_BookBuddies.Models;
using System.Diagnostics;
using System.Drawing;

namespace Showcase_BookBuddies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBookList(string listTitle, string listDescription)
        {
            if (_signInManager.IsSignedIn(this.User))
            {
                string? userId = _userManager.GetUserId(this.User);
                var bookList = new BookList() { UserId = userId, ListTitle = listTitle, ListDescription = listDescription };
                _context.BookLists.Add(bookList);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

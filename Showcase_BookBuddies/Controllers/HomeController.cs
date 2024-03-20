using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Showcase_BookBuddies.Business.Entities;
using Showcase_BookBuddies.Data;
using Showcase_BookBuddies.Migrations;
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
        [Authorize]
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(this.User))
            {
                string? userId = _userManager.GetUserId(this.User);
                if (userId is not null)
                {
                    //var userBookList = _context.BookLists.Where(b => b.UserId == userId);
                    var bookLists = _context.BookLists
                                    // voeg books toe aan de booklists
                                    .Include(b => b.Books) 
                                    .Where(b => b.UserId == userId)
                                    .ToList();
                    return View(bookLists);
                }
            }
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddBookList(string listTitle, string listDescription)
        {
            if (_signInManager.IsSignedIn(this.User))
            {
                string? userId = _userManager.GetUserId(this.User);
                // checkt of de user bestaat of niet en of deze een list heeft
                bool hasList = _context.BookLists.Any(b => b.UserId == userId);
                // checken of de gebruiker al een lijst heeft
                if (!hasList) 
                { 
                    // toevoegen van de opgegeven informatie aan een nieuwe lijst
                    BookList bookList = new BookList() { UserId = userId, ListTitle = listTitle, ListDescription = listDescription };
                    _context.BookLists.Add(bookList);
                    _context.SaveChanges();
                }
                else
                { // als de gebruiker al een lijst heeft, geef deze terug
                    var bookList = _context.BookLists.Where(b => b.UserId == userId);
                }
            }
            // ga terug naar de index pagina
            return RedirectToAction(nameof(Index));

        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBooks(string bookTitle, string bookAuthor)
        {
            if (_signInManager.IsSignedIn(this.User))
            {
                string? userId = _userManager.GetUserId(this.User);
                bool hasList = _context.BookLists.Any(b => b.UserId == userId);
                if (!hasList)
                {
                    return RedirectToAction(nameof(Index));
                }
                else // error als je niks invult
                {
                    int bookListId = _context.BookLists.Where(b => b.UserId == userId).Select(b => b.Id).ToList().FirstOrDefault();
                    Book books = new Book() { UserId = userId, BookTitle = bookTitle, BookAuthor = bookAuthor, BookListId = bookListId };
                    _context.Books.Add(books);
                    _context.SaveChanges();
                }

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

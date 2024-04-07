using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Showcase_BookBuddies.Business.Entities;
using Showcase_BookBuddies.Data;
using Showcase_BookBuddies.Hubs;
using Showcase_BookBuddies.Migrations;
using Showcase_BookBuddies.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace Showcase_BookBuddies.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHubContext<UpdateList> _updateList;
        private ILogger<HomeController> @object;

        //public HomeController(ILogger<HomeController> logger, 
        //    UserManager<IdentityUser> userManager, 
        //    ApplicationDbContext context, 
        //    SignInManager<IdentityUser> signInManager
        //    )
        //{
        //    _logger = logger;
        //    _userManager = userManager;
        //    _context = context;
        //    _signInManager = signInManager;

        //}

        public HomeController(ILogger<HomeController> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context,
            IHubContext<UpdateList> updateList
            )
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
            _updateList = updateList;
        }

        public HomeController(ILogger<HomeController> @object)
        {
            this.@object = @object;
        }

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
                                    .Include(bl => bl.Books)
                                    .Where(bl => bl.UserId == userId)
                                    .ToList();
                    return View(bookLists);
                }
            }
            return View();
        }
        public IActionResult ChatHub()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBookList(string listTitle, string listDescription)
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
                    BookList bookList = new BookList() { 
                        UserId = userId, 
                        ListTitle = listTitle, 
                        ListDescription = listDescription 
                    };
                    _context.BookLists.Add(bookList);
                    _context.SaveChanges();
                    await _updateList.Clients.All.SendAsync("SendUpdate");

                }
                else
                { // als de gebruiker al een lijst heeft, geef deze terug
                    var bookList = _context.BookLists.Where(b => b.UserId == userId);
                }
            }
            // ga terug naar de index pagina
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> AddBooks(string bookTitle, string bookAuthor)
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
                    int bookListId = _context.BookLists
                        .Where(bli => bli.UserId == userId)
                        .Select(bli => bli.Id)
                        .ToList()
                        .FirstOrDefault();
                    Book books = new Book() { 
                        UserId = userId, 
                        BookTitle = bookTitle, 
                        BookAuthor = bookAuthor, 
                        BookListId = bookListId 
                    };
                    _context.Books.Add(books);
                    _context.SaveChanges();
                    await _updateList.Clients.All.SendAsync("SendUpdate");

                }

            }

            return RedirectToAction(nameof(Index));

        }
        public IActionResult AllLists()
        {
            if (_signInManager.IsSignedIn(this.User))
            {
                string? userId = _userManager.GetUserId(this.User);
                if (userId is not null)
                {
                    var bookLists = _context.BookLists
                                    // voeg books toe aan de booklists
                                    .Include(b => b.Books)
                                    .Where(b => b.UserId != userId)
                                    .ToList();
                    return View(bookLists);
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLibrary()
        {
            if (_signInManager.IsSignedIn(this.User))
            {
                string? userId = _userManager.GetUserId(this.User);
                if (userId is not null)
                {
                    var bookLists = _context.BookLists
                                    // voeg alle boekenlijsten toe aan de pagina
                                    .Include(b => b.Books)
                                    .ToList();
                    return View(bookLists);
                }
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteBookList()
        {
            if (_signInManager.IsSignedIn(this.User))
            {
                if (ModelState.IsValid)
                { 
                    int listId = Convert.ToInt32(Request.Form["listId"]);
                    var bookListToDelete = _context.BookLists
                                    .Where(b => b.Id == listId)
                                    .FirstOrDefault();
                    var booksToDelete = _context.Books
                        .Where(b => b.BookListId == listId)
                        .ToList();

                    if (bookListToDelete is not null)
                    {
                        foreach (var books in booksToDelete)
                        {
                            // Delete the books first, before deleting the list, because there's a connection between the two tables
                            _context.Books.Remove(books);
                        }
                        _context.SaveChanges();

                        // Delete the book list
                        _context.BookLists.Remove(bookListToDelete);
                        _context.SaveChanges();
                        await _updateList.Clients.All.SendAsync("SendUpdate");

                    }
                    else
                    {
                        Console.WriteLine("Book list not found.");
                    }
                }
            }
            return RedirectToAction(nameof(DeleteLibrary));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

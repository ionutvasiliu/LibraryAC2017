using LibraryAC.Models;
using LibraryAC.Models.LibraryViewModels;
using LibraryAC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace LibraryAC.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        private readonly UserManager<ApplicationUser> _userManager;

        public LibraryController(ILibraryService libraryService, UserManager<ApplicationUser> userManager)
        {
            _libraryService = libraryService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var books = _libraryService.GetAllBooks();

            var transactions = _libraryService.GetTransactions();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _userManager.Users.FirstOrDefault(u => u.Id == userId);

            var model = new LibraryViewModel(books, transactions, user);

            return View(model);
        }

        public IActionResult Borrow(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var isSaved = _libraryService.Borrow(id, userId);

            var borrowViewModel = new BorrowViewModel()
            {
                IsSuccessfull = isSaved,
                BookName = _libraryService.GetAllBooks().Single(book => book.Id == id)?.Name
            };

            return View(borrowViewModel);
        }

        public IActionResult Return(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            bool isSuccessful = _libraryService.Return(id, userId);

            var returnViewModel = new ReturnViewModel
            {
                IsSuccessful = isSuccessful,
                BookName = _libraryService.GetAllBooks().Single(book => book.Id == id)?.Name
            };

            return View(returnViewModel);
        }
    }
}
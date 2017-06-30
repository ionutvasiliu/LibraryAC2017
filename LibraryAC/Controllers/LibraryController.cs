using LibraryAC.Models.LibraryViewModels;
using LibraryAC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace LibraryAC.Controllers
{
    [Authorize]
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        public IActionResult Index()
        {
            var books = _libraryService.GetAllBooks();

            var transactions = _libraryService.GetTransactions();

            var model = new LibraryViewModel(books, transactions);

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
    }
}
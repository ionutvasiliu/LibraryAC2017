using LibraryAC.Models.LibraryViewModels;
using LibraryAC.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAC.Controllers
{
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

            var model = new LibraryViewModel(books);

            return View(model);
        }
    }
}
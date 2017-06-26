using System.Collections.Generic;
using System.Linq;
using LibraryAC.Data;

namespace LibraryAC.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ApplicationDbContext _context;

        public LibraryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> GetAllBooks()
        {
            return _context.Books.ToList();
            //return new List<Book>()
            //{
            //    new Book() { Id = 1, Name = "Book #10", Author = "Author #1"},
            //    new Book() { Id = 2, Name = "Book #20", Author = "Author #1" },
            //    new Book() { Id = 3, Name = "Book #30", Author = "Author #2" }
            //};
        }
    }
}
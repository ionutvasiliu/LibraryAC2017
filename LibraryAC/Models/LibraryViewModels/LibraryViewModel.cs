using System.Collections.Generic;
using LibraryAC.Data.Entities;
using System.Linq;

namespace LibraryAC.Models.LibraryViewModels
{
    public class LibraryViewModel
    {
        private IList<Transaction> transactions;

        public IList<BookModel> Books { get; set; }

        public LibraryViewModel(IList<Book> books, IList<Transaction> transactions)
        {
            Books = new List<BookModel>();
            foreach (var book in books)
            {
                Books.Add(new BookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    IsBorrowed = transactions.Any(t => t.BookId == book.Id)
                });
            }
        }

    }
}
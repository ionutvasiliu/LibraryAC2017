using System.Collections.Generic;
using LibraryAC.Data.Entities;

namespace LibraryAC.Models.LibraryViewModels
{
    public class LibraryViewModel
    {
        public IList<BookModel> Books { get; set; }

        public LibraryViewModel(IList<Book> books)
        {
            Books = new List<BookModel>();
            foreach (var book in books)
            {
                Books.Add(new BookModel()
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author
                });
            }
        }
    }
}
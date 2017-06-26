using System.Collections.Generic;
using LibraryAC.Data;

namespace LibraryAC.Services
{
    public interface ILibraryService
    {
        IList<Book> GetAllBooks();
    }
}

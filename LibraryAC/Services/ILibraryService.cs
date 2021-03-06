﻿using System.Collections.Generic;
using LibraryAC.Data.Entities;

namespace LibraryAC.Services
{
    public interface ILibraryService
    {
        IList<Book> GetAllBooks();

        IList<Transaction> GetTransactions();
        bool Borrow(int id, string userId);
        bool Return(int id, string userId);
    }
}

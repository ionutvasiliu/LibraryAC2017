using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAC.Data;
using LibraryAC.Data.Entities;
using Microsoft.EntityFrameworkCore;

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
        }

        public IList<Transaction> GetTransactions()
        {
            return _context.Transactions.Include(m => m.User).ToList();
        }
    }
}
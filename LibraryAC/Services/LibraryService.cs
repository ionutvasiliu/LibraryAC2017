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

        public bool Borrow(int id, string userId)
        {
            _context.Transactions.Add(new Transaction()
            {
                BookId = id,
                UserId = userId
            });

            return _context.SaveChanges() == 1;
        }

        public IList<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public IList<Transaction> GetTransactions()
        {
            return _context.Transactions.Include(m => m.User).ToList();
        }

        public bool Return(int id, string userId)
        {
            var transaction = _context.Transactions.Single(t => t.UserId == userId && t.BookId == id);

            _context.Transactions.Remove(transaction);

            return _context.SaveChanges() == 1;
        }
    }
}
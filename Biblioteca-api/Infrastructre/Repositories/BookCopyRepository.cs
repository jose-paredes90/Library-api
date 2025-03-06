using System;
using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using Biblioteca_api.Enums;
using Biblioteca_api.Infrastructre.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_api.Infrastructre.Repositories
{
    public class BookCopyRepository : IBookCopyRepository
    {
        private readonly BooksContext _context;

        public BookCopyRepository(BooksContext context)
        {
            _context = context;
        }

        public async Task<BookCopy> Add(BookCopy bookCopy)
        {
            _context.BookCopies.Add(bookCopy);
            await _context.SaveChangesAsync();
            return bookCopy;
        }

        public async Task<BookCopy?> GetByBarcode(string barcode)
        {
            return await _context.BookCopies.FirstOrDefaultAsync(bc => bc.Barcode == barcode);
        }

        public async Task<int> GetCountBooks(int bookId)
        {
            return await _context.BookCopies.Where(bc => bc.BookId == bookId && bc.Status == (int)BookCopyStatusEnum.Available).CountAsync();
        }

        public async Task<IEnumerable<BookCopy>> GetAllBookCopy()
        {
            return await _context.BookCopies.Include(b => b.Book).ToListAsync();
        }


    }
}


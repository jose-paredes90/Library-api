using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using Biblioteca_api.Enums;
using Biblioteca_api.Infrastructre.DataContext;
using Microsoft.EntityFrameworkCore;
using System;

namespace Biblioteca_api.Infrastructre.Repositories
{
    public class LoanRepository : ILoanRepository
    {

        private readonly BooksContext _context;

        public LoanRepository(BooksContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loan>> GetAll()
        {
            return await _context.Loans
                .Include(l => l.Client)
                .ThenInclude(c => c.User)
                .Include(l => l.BookCopy)
                .ThenInclude(bc => bc.Book)
                .ToListAsync();
        }

        public async Task<Loan> GetById(int id)
        {
            return await _context.Loans
                .Include(l => l.Client)
                .ThenInclude(c => c.User)
                .Include(l => l.BookCopy)
                .ThenInclude(bc => bc.Book)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<bool> IsBookAvailable(int bookCopyId)
        {
            var bookCopy = await _context.BookCopies.FindAsync(bookCopyId);
            return bookCopy != null && bookCopy.Status == (int)BookCopyStatusEnum.Available;
        }

        public async Task Add(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
            var bookCopy = await _context.BookCopies.FindAsync(loan.BookCopyId);
            if (bookCopy != null)
            {
                bookCopy.Status = (int)BookCopyStatusEnum.Borrowed;
            }
            await _context.SaveChangesAsync();
        }

        public async Task Update(Loan loan)
        {
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }

    }
}


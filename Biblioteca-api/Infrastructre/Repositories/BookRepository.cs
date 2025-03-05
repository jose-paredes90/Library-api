using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using Biblioteca_api.Infrastructre.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_api.Infrastructre.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BooksContext context;

        public BookRepository(BooksContext context)
        {
            this.context = context;
        }
        public async Task Add(Books books)
        {
            await context.Books.AddAsync(books);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Books>> GetAll()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Books> GetById(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task Update(Books books)
        {
            context.Books.Update(books);
            context.SaveChangesAsync();
        }
        public async Task Delete(Books employee)
        {
            context.Books.Remove(employee);
            await context.SaveChangesAsync();
        }
    }
}

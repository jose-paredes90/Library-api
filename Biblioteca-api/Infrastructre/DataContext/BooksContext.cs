using Biblioteca_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_api.Infrastructre.DataContext
{
    public class BooksContext: DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }


    }
}

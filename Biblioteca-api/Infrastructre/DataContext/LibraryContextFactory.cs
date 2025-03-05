using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Biblioteca_api.Infrastructre.DataContext
{
    public class LibraryContextFactory : IDesignTimeDbContextFactory<BooksContext>
    {
        public BooksContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<BooksContext>();
            optionBuilder.UseSqlServer("Server=DESKTOP-5P3P4O1;Database=LibraryDb;Trusted_connection=true;User Id=sa;Password=12345678;TrustServerCertificate=true");

            return new BooksContext(optionBuilder.Options);
        }
    }
}
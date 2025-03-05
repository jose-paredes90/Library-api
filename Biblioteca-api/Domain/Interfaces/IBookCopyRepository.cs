using System;
using Biblioteca_api.Domain.Entities;

namespace Biblioteca_api.Domain.Interfaces
{
	public interface IBookCopyRepository
	{
        Task<BookCopy> Add(BookCopy bookCopy);
        Task<IEnumerable<BookCopy>> GetAllBookCopy();
        Task<BookCopy?> GetByBarcode(string barcode);
    }
}


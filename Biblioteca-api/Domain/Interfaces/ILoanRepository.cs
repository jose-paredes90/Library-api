using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Domain.Entities;
using System;

namespace Biblioteca_api.Domain.Interfaces
{
	public interface ILoanRepository
	{
        Task<IEnumerable<Loan>> GetAll();
        Task<Loan> GetById(int id);
        Task<bool> IsBookAvailable(int bookId);
        Task Add(Loan loan);
        Task Update(Loan loan);
        Task Delete(int id);
    }
}


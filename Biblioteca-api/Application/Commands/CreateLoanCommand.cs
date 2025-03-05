using Biblioteca_api.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_api.Application.Commands
{
    public class CreateLoanCommand : IRequest<bool>
    {
  
        public int ClientId { get; set; }

        public int BookCopyId { get; set; }

        public DateTime StartDate { get; set; }
   
        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int Status { get; set; }
    }
}

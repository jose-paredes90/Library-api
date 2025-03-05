using Biblioteca_api.Domain.Entities;
using MediatR;

namespace Biblioteca_api.Application.Commands
{
    public class CreateBookCopyCommand : IRequest<BookCopy>
    {
        public string Barcode { get; set; }
        public int BookId { get; set; }
    }
}

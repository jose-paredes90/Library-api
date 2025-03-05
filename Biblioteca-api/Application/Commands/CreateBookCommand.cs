using Biblioteca_api.Domain.Entities;
using MediatR;

namespace Biblioteca_api.Application.Commands
{
    public class CreateBookCommand : IRequest<Books>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}

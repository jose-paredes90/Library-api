using MediatR;

namespace Biblioteca_api.Application.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}

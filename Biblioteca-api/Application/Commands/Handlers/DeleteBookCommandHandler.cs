using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Commands.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.Id);
            if (book == null)
                throw new Exception("Empleado no encontrado");

            await _bookRepository.Delete(book);
        }
    }
}

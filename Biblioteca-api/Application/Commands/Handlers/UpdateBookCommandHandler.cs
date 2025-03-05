using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Commands.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetById(request.Id);
            if (book == null) throw new Exception("Empleado no encontrado");

            book.Author = request.Author;
            book.Title = request.Title;
            book.Price = request.Price;
            book.Category = request.Category;
            book.Title = request.Title ?? string.Empty;

            await _bookRepository.Update(book);
            
            return book.Id;
        }
    }
}

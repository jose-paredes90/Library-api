using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Commands.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Books>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Books> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Books()
            {
                Author = request.Author,
                Title = request.Title,  
                Price = request.Price,   
                Category = request.Category,
            };

            await _bookRepository.Add(book);
            return book;
        }
    }
}

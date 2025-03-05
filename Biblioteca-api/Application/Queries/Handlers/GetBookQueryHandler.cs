using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Queries.Handlers
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, IEnumerable<BooksDto>>
    {
        private readonly IBookRepository _bookRepository;
        public GetBookQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BooksDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAll();
            return books.Select(e => new BooksDto
            {
                Id = e.Id,
                Author = e.Author,
                Category = e.Category,
                Price = e.Price,
                Title = e.Title
                
            });
        }
    }

    
}

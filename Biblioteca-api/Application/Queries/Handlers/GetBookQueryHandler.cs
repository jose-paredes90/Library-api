using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Queries.Handlers
{
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, IEnumerable<BooksDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookCopyRepository bookCopyRepository;
        public GetBookQueryHandler(IBookRepository bookRepository, IBookCopyRepository bookCopyRepository)
        {
            _bookRepository = bookRepository;
            this.bookCopyRepository = bookCopyRepository;
        }

        public async Task<IEnumerable<BooksDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAll();

            var booksDtoList = new List<BooksDto>();
            foreach (var e in books)
            {
                var stock = await this.bookCopyRepository.GetCountBooks(e.Id);
                booksDtoList.Add(new BooksDto
                {
                    Id = e.Id,
                    Author = e.Author,
                    Category = e.Category,
                    Price = e.Price,
                    Title = e.Title,
                    Stock = stock
                });
            }

            return booksDtoList;
        }
    }

    
}

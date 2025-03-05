using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Queries.Handlers
{
    public class GetBookCopyQueryHandler : IRequestHandler<GetBookCopyQuery, IEnumerable<BookCopyDto>>
    {
        private readonly IBookCopyRepository _bookCopyRepository;

        public GetBookCopyQueryHandler(IBookCopyRepository bookCopyRepository)
        {
            _bookCopyRepository = bookCopyRepository;
        }

        public async Task<IEnumerable<BookCopyDto>> Handle(GetBookCopyQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookCopyRepository.GetAllBookCopy();
            return books.Select(b => new BookCopyDto()
            {
                Barcode = b.Barcode,
                Id = b.Id,
                Status = b.Status,
                Book = new BooksDto()
                {
                    Id = b.Book.Id,
                    Author = b.Book.Author,
                    Category = b.Book.Category,
                    Price = b.Book.Price,
                    Title = b.Book.Title
                }
            });
        }
    }
}

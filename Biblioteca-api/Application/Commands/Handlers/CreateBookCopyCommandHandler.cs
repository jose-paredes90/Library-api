using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using Biblioteca_api.Enums;
using Biblioteca_api.Infrastructre.Repositories;
using MediatR;

namespace Biblioteca_api.Application.Commands.Handlers
{
    public class CreateBookCopyCommandHandler : IRequestHandler<CreateBookCopyCommand, BookCopy>
    {
        private readonly IBookCopyRepository _bookCopyRepository;

        public CreateBookCopyCommandHandler(IBookCopyRepository _bookCopyRepository)
        {
            this._bookCopyRepository = _bookCopyRepository;
        }

        public async Task<BookCopy> Handle(CreateBookCopyCommand request, CancellationToken cancellationToken)
        {
            var book = new BookCopy()
            {
                Barcode = request.Barcode,
                BookId = request.BookId,
                Status = (int)BookCopyStatusEnum.Available
            };

            await _bookCopyRepository.Add(book);
            return book;
        }
    }
}

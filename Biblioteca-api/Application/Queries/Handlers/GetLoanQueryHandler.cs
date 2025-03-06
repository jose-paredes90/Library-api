using Biblioteca_api.Application.Dtos;
using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Queries.Handlers
{
    public class GetLoanQueryHandler : IRequestHandler<GetLoanQuery, IEnumerable<LoanDto>>
    {
        private readonly ILoanRepository loanRepository;

        public GetLoanQueryHandler(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository;
        }
        public async Task<IEnumerable<LoanDto>> Handle(GetLoanQuery request, CancellationToken cancellationToken)
        {
            var loans = await loanRepository.GetAll();
            return loans.Select(l => new LoanDto
            {
                Id = l.Id,
                ClientName = $"{l.Client.User.Name}",
                BookCopyId = l.BookCopyId,
                BookTitle = l.BookCopy.Book.Title,
                StartDate = l.StartDate,
                DueDate = l.DueDate,
                ReturnDate = l.ReturnDate,
                Status = l.BookCopy.Status,
                Barcode = l.BookCopy.Barcode,
                ClientId = l.ClientId
            });
        }
    }
}

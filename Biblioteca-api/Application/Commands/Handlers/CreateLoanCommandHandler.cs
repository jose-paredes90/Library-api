using Biblioteca_api.Domain.Entities;
using Biblioteca_api.Domain.Interfaces;
using Biblioteca_api.Enums;
using Biblioteca_api.Infrastructre.Repositories;
using MediatR;

namespace Biblioteca_api.Application.Commands.Handlers
{
    public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, bool>
    {
        private readonly ILoanRepository loanRepository;

        public CreateLoanCommandHandler(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository;
        }
        public async Task<bool> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            if (!await loanRepository.IsBookAvailable(request.BookCopyId))
                return false;

            var loan = new Loan
            {
                ClientId = request.ClientId,
                BookCopyId = request.BookCopyId,
                StartDate = DateTime.Now,
                DueDate = request.DueDate,
                Status = (int)BookCopyStatusEnum.Available
            };

            await loanRepository.Add(loan);
            return true;
        }
    }
}

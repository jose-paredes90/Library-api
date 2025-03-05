using Biblioteca_api.Domain.Interfaces;
using MediatR;

namespace Biblioteca_api.Application.Commands.Handlers
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, int>
    {
        private readonly ILoanRepository loanRepository;

        public UpdateLoanCommandHandler(ILoanRepository loanRepository)
        {
            this.loanRepository = loanRepository;
        }
        public async Task<int> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await loanRepository.GetById(request.ClientId);
            if (loan == null)
                throw new Exception("El registro no existe");

            loan.ClientId = request.ClientId;
            loan.BookCopyId = request.BookCopyId;
            loan.DueDate = request.DueDate;
            await loanRepository.Update(loan);
            return loan.Id;
        }
    
    }
}

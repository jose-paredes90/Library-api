using Biblioteca_api.Domain.Interfaces;
using Biblioteca_api.Infrastructre.Repositories;
using MediatR;

namespace Biblioteca_api.Application.Commands.Handlers
{
    public class DeleteLoanCommandHandler : IRequestHandler<DeleteLoanCommand>
    {
        private readonly ILoanRepository _loanRepository;

        public DeleteLoanCommandHandler(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }
        public async Task Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
        {
            var loan = await _loanRepository.GetById(request.Id);
            if (loan == null)
                throw new Exception("Empleado no encontrado");
            await _loanRepository.Delete(loan.Id);

        }
    }
}

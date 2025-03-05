using MediatR;

namespace Biblioteca_api.Application.Commands
{
    public class DeleteLoanCommand: IRequest
    {
        public int Id { get; set; }
    }
}

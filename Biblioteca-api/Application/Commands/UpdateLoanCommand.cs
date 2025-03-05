using MediatR;

namespace Biblioteca_api.Application.Commands
{
    public class UpdateLoanCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }

        public int BookCopyId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public int Status { get; set; }
    }
}

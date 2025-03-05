using System;
namespace Biblioteca_api.Application.Dtos
{
	public class LoanUpdateRequestDto
	{
        public int ClientId { get; set; }
        public int BookCopyId { get; set; }
        public DateTime DueDate { get; set; }
    }
}


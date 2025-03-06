using System;
namespace Biblioteca_api.Application.Dtos
{
	public class LoanDto
	{
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public int BookCopyId { get; set; }
        public string BookTitle { get; set; }
        public string Barcode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Status { get; set; }
    }
}


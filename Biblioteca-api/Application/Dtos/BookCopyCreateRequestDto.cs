using System;
namespace Biblioteca_api.Application.Dtos
{
	public class BookCopyCreateRequestDto
	{
        public int BookId { get; set; }
        public string Barcode { get; set; }
    }
}


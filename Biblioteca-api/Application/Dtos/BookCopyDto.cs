using System;
namespace Biblioteca_api.Application.Dtos
{
	public class BookCopyDto
	{
		public int Id { get; set; }
		public BooksDto Book { get; set; }
        public string Barcode { get; set; }
        public int Status { get; set; }
    }
}


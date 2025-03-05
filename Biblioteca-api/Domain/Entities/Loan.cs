using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_api.Domain.Entities
{
	public class Loan
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int BookCopyId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

		public DateTime? ReturnDate { get; set; }

        [Required]
        public int Status { get; set; }


        public Client Client { get; set; }
        public BookCopy BookCopy { get; set; }
    }
}


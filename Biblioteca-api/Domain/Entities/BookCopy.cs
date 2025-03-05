using Biblioteca_api.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_api.Domain.Entities
{
	public class BookCopy
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }
        public Books Book { get; set; }

        [Required, MaxLength(50)]
        public string Barcode { get; set; }

        [Required]
        public int Status { get; set; }

    }
}


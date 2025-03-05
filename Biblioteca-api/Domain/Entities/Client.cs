using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca_api.Domain.Entities
{
	public class Client
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(10)]
        public string DocumentNumber { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        public User User { get; set; }
    }
}


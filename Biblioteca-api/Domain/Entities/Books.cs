using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_api.Domain.Entities
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(120)]
        public string Title { get; set; }

        [Required, MaxLength(100)]
        public string Author { get; set; }

        [Required, MaxLength(80)]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<BookCopy> Copies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Libro
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Titolo { get; set; }

        [Required]
        [StringLength(50)]
        public required string Autore { get; set; }

        [Required]
        [StringLength(50)]
        public required string Genere { get; set; }

        [Required]
        public required Boolean Disponibilità { get; set; }

        public string? Copertina { get; set; }
    }
}

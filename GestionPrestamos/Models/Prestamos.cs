using System.ComponentModel.DataAnnotations;

namespace GestionPrestamos.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; } 

        [Required(ErrorMessage = "Campo requerido")]
        public string Concepto { get; set; } = null!;
    }
}

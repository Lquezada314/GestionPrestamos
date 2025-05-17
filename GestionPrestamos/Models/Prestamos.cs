using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrestamos.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; } 

        [Required(ErrorMessage = "Campo requerido")]
        public string Concepto { get; set; } = null!;

        public int Monto { get; set; }

        public int Balance { get; set; }

        [ForeignKey("DeudorId")]
        public int DeudorId { get; set; }

        public virtual Deudores Deudores { get; set; } = null!;
    }
}

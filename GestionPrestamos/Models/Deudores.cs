using System.ComponentModel.DataAnnotations;

namespace GestionPrestamos.Models
{
    public class Deudores
    {
        [Key]
        public int DeudorId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Nombres { get; set; } = string.Empty;
    }
}

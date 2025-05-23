using System.ComponentModel.DataAnnotations;

namespace GestionPrestamos.Models
{
    public class Deudores
    {
        [Key]
        public int DeudorId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Nombres { get; set; } = string.Empty;

        //Campo para indicar si ya saldo el prestamo o tiene un balance pendiente, o su caso esta en proceso de creacion
        public string EstadoDeuda { get; set; } = string.Empty;
    }
}

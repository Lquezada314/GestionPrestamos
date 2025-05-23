using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrestamos.Models
{

    public class Deudores
    {
        [Key]
        public int DeudorId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string NombresDeudor { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        public int RncDeudor { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal LimiteCredito { get; set; }

        //Campo para indicar si ya saldo el prestamo o tiene un balance pendiente, o su caso esta en proceso de creacion
        public string EstadoDeuda { get; set; } = string.Empty;



    }
}

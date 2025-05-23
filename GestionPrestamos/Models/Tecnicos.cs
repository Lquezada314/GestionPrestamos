using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPrestamos.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string NombresTecnico { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SueldoxHora { get; set; }
    }
}

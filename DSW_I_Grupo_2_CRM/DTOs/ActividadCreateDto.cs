using System.ComponentModel.DataAnnotations;

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class ActividadCreateDto : IValidatableObject
    {
        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public string Tipo { get; set; } // Llamada, Reunión, Email, etc.

        public DateTime? Fecha { get; set; } // opcional, backend puede asignar

        public string Descripcion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(Tipo))
            {
                yield return new ValidationResult("El tipo de actividad es obligatorio");
            }
        }
    }
}

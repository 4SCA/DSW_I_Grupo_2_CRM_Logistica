using System.ComponentModel.DataAnnotations;

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class ClienteCreateDto : IValidatableObject
    {
        [Required]
        public string TipoCliente { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Contacto { get; set; } //Nombre de la persona que te respondio
        public string CargoContacto { get; set; } //Cargo de la persona con la que te contesto a nombre de la empresa
        public string Telefono { get; set; }

        [EmailAddress]
        public string Correo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (TipoCliente == "Empresa")
            {
                if (string.IsNullOrEmpty(Ruc))
                    yield return new ValidationResult("RUC obligatorio");

                if (Ruc?.Length != 11)
                    yield return new ValidationResult("RUC inválido");
            }
        }
    }
}

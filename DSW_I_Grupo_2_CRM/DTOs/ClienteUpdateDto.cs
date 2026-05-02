using System.ComponentModel.DataAnnotations;

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class ClienteUpdateDto : IValidatableObject
    {
        public string TipoCliente { get; set; }
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string Contacto { get; set; }
        public string CargoContacto { get; set; }
        public string Telefono { get; set; }

        [EmailAddress]
        public string Correo { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (TipoCliente == "Empresa")
            {
                if (!string.IsNullOrEmpty(Ruc) && Ruc.Length != 11)
                    yield return new ValidationResult("RUC inválido");
            }
        }
    }
}

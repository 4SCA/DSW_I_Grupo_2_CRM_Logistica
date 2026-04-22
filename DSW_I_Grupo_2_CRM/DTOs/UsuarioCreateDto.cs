using System.ComponentModel.DataAnnotations;

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class UsuarioCreateDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public int IdRol {  get; set; }
    }
}

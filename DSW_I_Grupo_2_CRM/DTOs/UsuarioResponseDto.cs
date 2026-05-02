namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class UsuarioResponseDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        public string RolNombre {  get; set; }
        public string Token { get; set; }
    }
}

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class LoginResponseDto
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int IdRol { get; set; }

        public string Token { get; set; }
    }
}

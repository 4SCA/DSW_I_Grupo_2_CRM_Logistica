namespace DSW_I_Grupo_2_CRM.Models
{
    public class RolModel
    {
        public int Id { get; set; }
        public string NombreRol { get; set; }

        // Navegación inversa
        public List<UsuarioModel> Usuarios { get; set; } = new();
    }
}

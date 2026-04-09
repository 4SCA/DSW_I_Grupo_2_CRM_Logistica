namespace DSW_I_Grupo_2_CRM.Models
{
    public class BloqueUsuarioModel
    {
        public int IdBloque { get; set; }
        public BloqueModel Bloque { get; set; }

        public int IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}

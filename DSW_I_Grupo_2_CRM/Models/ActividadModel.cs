namespace DSW_I_Grupo_2_CRM.Models
{
    public class ActividadModel
    {
        public int IdActividad {  get; set; }
        public int IdCliente { get; set; }
        public ClienteModel Cliente { get; set; }
        public int IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set;  }
    }
}

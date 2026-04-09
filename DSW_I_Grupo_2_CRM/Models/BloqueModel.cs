namespace DSW_I_Grupo_2_CRM.Models
{
    public class BloqueModel
    {
        public int IdBloque { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public List<BloqueClienteModel> BloqueClientes { get; set; } = new();
        public List<BloqueUsuarioModel> BloqueUsuarios { get; set; } = new();
    }
}

namespace DSW_I_Grupo_2_CRM.Models
{
    public class BloqueClienteModel
    {
        public int IdBloque { get; set; }
        public BloqueModel Bloque { get; set; }
        public int IdCliente { get; set; }
        public ClienteModel Cliente { get; set; }
    }
}

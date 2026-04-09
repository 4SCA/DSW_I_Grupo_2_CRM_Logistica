namespace DSW_I_Grupo_2_CRM.Models
{
    public class SeguimientoModel
    {
        public int IdSeguimiento { get; set; }
        public int IdEnvio { get; set; }
        public EnvioModel Envio { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
    }
}

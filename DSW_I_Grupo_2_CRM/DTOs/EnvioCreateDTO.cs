namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class EnvioCreateDTO
    {
        public int IdCotizacion { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }

        public DateTime? FechaEnvio { get; set; }
    }
}

namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class CotizacionCreateDto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }

        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Modalidades { get; set; }
        public string TipoServicio { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}

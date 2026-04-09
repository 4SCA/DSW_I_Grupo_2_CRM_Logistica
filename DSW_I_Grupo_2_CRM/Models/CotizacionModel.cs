namespace DSW_I_Grupo_2_CRM.Models
{
    public class CotizacionModel
    {
        public int IdCotizacion { get; set; }
        public string NumeroCorrelativo { get; set; }
        public int IdCliente { get; set; }
        public ClienteModel Cliente { get; set; }

        public int IdUsuario { get; set; }
        public UsuarioModel Usuario { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Modalidad { get; set; }
        public string TipoServicio { get; set; }
        public string Proveedor { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }

        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }

        public List<HistorialCotizacionModel> Historial { get; set; } = new();
        public List<EnvioModel> Envios { get; set; } = new();
    }
}

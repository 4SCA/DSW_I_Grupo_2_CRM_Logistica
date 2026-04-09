using System.ComponentModel.DataAnnotations;

namespace DSW_I_Grupo_2_CRM.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Ruc {  get; set; }
        public string RazonSocial { get; set; }
        public string Contacto { get; set; }
        public string CargoContacto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string TipoCliente { get; set; }
        public string Notas { get; set; }

        public List<ActividadModel> Actividades { get; set; } = new();
        public List<CotizacionModel> Cotizaciones { get; set; } = new();
        public List<BloqueClienteModel> BloqueClientes { get; set; } = new();

    }
}

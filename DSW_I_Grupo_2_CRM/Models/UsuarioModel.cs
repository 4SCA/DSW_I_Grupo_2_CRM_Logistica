namespace DSW_I_Grupo_2_CRM.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }
        public RolModel Rol { get; set; }
        
        // Navegación inversa
        public List<ActividadModel> Actividades { get; set; } = new();
        public List<CotizacionModel> Cotizaciones { get; set; } = new();
        public List<BloqueUsuarioModel> BloqueUsuarios { get; set; } = new();
    }
}

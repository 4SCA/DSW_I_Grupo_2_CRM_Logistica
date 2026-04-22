namespace DSW_I_Grupo_2_CRM.DTOs
{
    public class ActividadResponseDto
    {
        public int IdActividad { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha {  get; set; }
        public string Descripcion { get; set; }
    }
}

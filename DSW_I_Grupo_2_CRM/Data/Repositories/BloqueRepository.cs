using Microsoft.Data.SqlClient;
using System.Data;

namespace DSW_I_Grupo_2_CRM.Data.Repositories
{
    public class BloquesRepository
    {
        private readonly string _connectionString;

        public BloquesRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conn");
        }

        public async Task<int> CrearBloqueAsync(string nombre)
        {
            int idBloque = 0;

            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_CrearBloque", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", nombre);

                await cn.OpenAsync();

                var result = await cmd.ExecuteScalarAsync();
                idBloque = Convert.ToInt32(result);
            }

            return idBloque;
        }

        public async Task<bool> AsignarUsuarioAsync(int idBloque, int idUsuario)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_AsignarUsuarioABloque", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_bloque", idBloque);
                    cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        // Asignar cliente a bloque
        public async Task<bool> AsignarClienteAsync(int idBloque, int idCliente)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("sp_AsignarClienteABloque", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_bloque", idBloque);
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
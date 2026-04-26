using DSW_I_Grupo_2_CRM.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DSW_I_Grupo_2_CRM.Data.Repositories
{
    public class AccountRepository
    {
        private readonly string _connectionString;

        public AccountRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conn");
        }

        public async Task<UsuarioResponseDto?> LoginAsync(UsuarioLoginDto loginDto)
        {
            UsuarioResponseDto response = null;

            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_ObtenerUsuarioLogin", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", loginDto.Correo);

                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        string hash = reader.GetString(3);

                        bool isValid = BCrypt.Net.BCrypt.Verify(loginDto.Clave, hash);

                        if (!isValid) 
                            return null;

                        response = new UsuarioResponseDto
                        {
                            IdUsuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Correo = reader.GetString(2),
                            Estado = reader.GetString(5),
                        };
                    }
                }
                    
            }
            return response;
        }

        public async Task RegisterAsync(UsuarioCreateDto dto)
        {
            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_RegistrarUsuario", cn))
            {
                string claveHasheada = BCrypt.Net.BCrypt.HashPassword(dto.Clave);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", dto.Nombre);
                cmd.Parameters.AddWithValue("@correo", dto.Correo);
                cmd.Parameters.AddWithValue("@clave", claveHasheada);
                cmd.Parameters.AddWithValue("@id_rol", dto.IdRol);
                await cn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}

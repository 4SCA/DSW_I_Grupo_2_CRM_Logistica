using DSW_I_Grupo_2_CRM.DTOs;
using Microsoft.Data.SqlClient;
using System.Data;
namespace DSW_I_Grupo_2_CRM.Data.Repositories
{
    public class ClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("Conn");
        }

        public async Task CrearClienteAsync (ClienteCreateDto dto)
        {
            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_CrearCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ruc", dto.Ruc ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@razon_social", dto.RazonSocial);
                cmd.Parameters.AddWithValue("@contacto", dto.Contacto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cargo_contacto", dto.CargoContacto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", dto.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@correo", dto.Correo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@tipo_cliente", dto.TipoCliente);

                await cn.OpenAsync();
                var id = await cmd.ExecuteNonQueryAsync();
                
            }
            

        }

        
        public async Task<ClienteResponseDTO?> ObtenerPorIdAsync(int idCliente, int idUsuario)
        {
            
            
            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_ObtenerClientePorId", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new ClienteResponseDTO
                        {
                            
                            IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                            TipoCliente = reader.GetString(reader.GetOrdinal("tipo_cliente")),
                            Ruc = reader.IsDBNull(reader.GetOrdinal("ruc")) ? null : reader.GetString(reader.GetOrdinal("ruc")),
                            RazonSocial = reader.GetString(reader.GetOrdinal("razon_social")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString(reader.GetOrdinal("telefono")),
                            Correo = reader.IsDBNull(reader.GetOrdinal("correo")) ? null : reader.GetString(reader.GetOrdinal("correo")),
                            Estado = reader.GetString(reader.GetOrdinal("estado"))
                        };
                    }
                }
            }
            return null;
        }

        public async Task ActualizarClienteAsync(int idCliente, ClienteUpdateDto dto, int idUsuario)
        {
            

            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_EditarCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd.Parameters.AddWithValue("@ruc", dto.Ruc ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@razon_social", dto.RazonSocial);
                cmd.Parameters.AddWithValue("@contacto", dto.Contacto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cargo_contacto", dto.CargoContacto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", dto.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@correo", dto.Correo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@tipo_cliente", dto.TipoCliente);

                await cn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }


        public async Task<List<ClienteResponseDTO>> ListarClientesAsync(int idUsuario)
        {
            var lista = new List<ClienteResponseDTO>();
            

            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_ListarClientes", cn)) 
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);

                await cn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var cliente = new ClienteResponseDTO
                        {
                            IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                            TipoCliente = reader.GetString(reader.GetOrdinal("tipo_cliente")),
                            Ruc = reader.IsDBNull(reader.GetOrdinal("ruc")) ? null : reader.GetString(reader.GetOrdinal("ruc")),
                            RazonSocial = reader.GetString(reader.GetOrdinal("razon_social")),
                            Contacto= reader.IsDBNull(reader.GetOrdinal("contacto")) ? null : reader.GetString(reader.GetOrdinal("contacto")),
                            CargoContacto = reader.IsDBNull(reader.GetOrdinal("cargo_contacto")) ? null : reader.GetString(reader.GetOrdinal("cargo_contacto")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("telefono")) ? null : reader.GetString(reader.GetOrdinal("telefono")),
                            Correo = reader.IsDBNull(reader.GetOrdinal("correo")) ? null : reader.GetString(reader.GetOrdinal("correo")),
                            Estado = reader.GetString(reader.GetOrdinal("estado"))
                        };

                        lista.Add(cliente);
                    }
                }
            }

            return lista;
        }

        public async Task ActualizarEstadoClienteAsync(ClienteEstadoDto dto, int idUsuario)
        {
            

            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_ActualizarEstadoCliente", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_cliente", dto.IdCliente);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd.Parameters.AddWithValue("@estado", dto.Estado);

                await cn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }


        public async Task<(List<ClienteResponseDTO> clientes, int totalRegistros)> ListarClientesPaginadoAsync(int page, int pageSize, int idUsuario)
        {
            var lista = new List<ClienteResponseDTO>();
            int totalRegistros = 0;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("sp_ListarClientesPaginado", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmd.Parameters.AddWithValue("@PageNumber", page);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    // Leer los registros de clientes
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new ClienteResponseDTO
                        {
                            IdCliente = reader.GetInt32(0),
                            TipoCliente = reader.GetString(1),
                            Ruc = reader.IsDBNull(2) ? null : reader.GetString(2),
                            RazonSocial = reader.GetString(3),
                            Contacto = reader.IsDBNull(4) ? null : reader.GetString(4),
                            CargoContacto = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Telefono = reader.IsDBNull(6) ? null : reader.GetString(6),
                            Correo = reader.IsDBNull(7) ? null : reader.GetString(7),
                            Estado = reader.GetString(8)
                        });
                    }

                    // Leer el total de registros (segundo resultset)
                    await reader.NextResultAsync();
                    if (await reader.ReadAsync())
                    {
                        totalRegistros = reader.GetInt32(0);
                    }
                }
            }

            return (lista, totalRegistros);
        }

    }
}

using DSW_I_Grupo_2_CRM.Data.Repositories;
using DSW_I_Grupo_2_CRM.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DSW_I_Grupo_2_CRM.Controllers.Api
{
    [ApiController]
    [Route("api/cliente")]
    [Authorize]
    public class ClienteApiController : ControllerBase
    {


        private readonly ClienteRepository _repo;

        public ClienteApiController(ClienteRepository repo)
        {
            _repo = repo;
        }

        private int ObtenerIdUsuario()
        {
            var claim = User.FindFirst("id");

            if (claim == null)
                throw new UnauthorizedAccessException("Token inválido");

            return int.Parse(claim.Value);
        }


        // ==================== CREAR ====================
        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] ClienteCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _repo.CrearClienteAsync(dto);
                return Ok(new { mensaje = "Cliente creado exitosamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        //Ejecuta

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            int idUsuario = ObtenerIdUsuario();

            var cliente = await _repo.ObtenerPorIdAsync(id, idUsuario);

            if (cliente == null)
                return NotFound(new { mensaje = "Cliente no encontrado o no tienes acceso" });

            return Ok(cliente);
        }

        [HttpGet("listar-general")]
        public async Task<IActionResult> ListarGeneral()
        {
            var clientes = await _repo.ListarClientesGeneralAsync();
            return Ok(clientes);
        }
        //Ejecuta

        [HttpGet("paginado")]
        public async Task<IActionResult> ListarPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            int idUsuario = ObtenerIdUsuario();

            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50;

            var (clientes, totalRegistros) = await _repo.ListarClientesPaginadoAsync(page, pageSize, idUsuario);

            return Ok(new
            {
                clientes,
                totalRegistros,
                totalPaginas = (int)Math.Ceiling(totalRegistros / (double)pageSize),
                page,
                pageSize
            });
        }
        //Ejecuta


        // ==================== ACTUALIZAR ====================
        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ClienteUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                int idUsuario = ObtenerIdUsuario();
                await _repo.ActualizarClienteAsync(id, dto, idUsuario);
                return Ok(new { mensaje = "Cliente actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        //Ejecuta

        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> ActualizarEstado(int id)
        {
            try
            {
                int idUsuario = ObtenerIdUsuario();

                var ok = await _repo.DesactivarClienteAsync(id, idUsuario);

                if (!ok)
                    return BadRequest(new { mensaje = "No se pudo desactivar el cliente o no tienes permisos" });

                return Ok(new { mensaje = "Estado actualizado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

    }
}

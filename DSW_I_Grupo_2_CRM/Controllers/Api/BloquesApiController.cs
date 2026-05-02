using DSW_I_Grupo_2_CRM.Data.Repositories;
using DSW_I_Grupo_2_CRM.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DSW_I_Grupo_2_CRM.Controllers
{
    [ApiController]
    [Route("api/bloques")]
    [Authorize]
    public class BloquesApiController : ControllerBase
    {
        private readonly BloquesRepository _repo;

        public BloquesApiController(BloquesRepository repo)
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

        [HttpPost("crear")]
        public async Task<IActionResult> Crear([FromBody] BloqueCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                return BadRequest("El nombre es obligatorio");

            var idBloque = await _repo.CrearBloqueAsync(dto.Nombre);

            return Ok(new { id_bloque = idBloque });
        }

        [HttpPost("asignar-usuario")]
        public async Task<IActionResult> AsignarUsuario([FromBody] AsignarUsuarioBloqueDto dto)
        {
            try
            {
                var idUsuario = ObtenerIdUsuario();

                var ok = await _repo.AsignarUsuarioAsync(dto.IdBloque, idUsuario);

                if (!ok)
                    return BadRequest("El usuario ya está asignado a este bloque");

                return Ok("Usuario asignado correctamente");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("asignar-cliente")]
        public async Task<IActionResult> AsignarCliente([FromBody] AsignarClienteBloqueDto dto)
        {
            var ok = await _repo.AsignarClienteAsync(dto.IdBloque, dto.IdCliente);

            if (!ok)
                return BadRequest("El cliente ya está asignado a este bloque");

            return Ok("Cliente asignado correctamente");
        }
    }
}
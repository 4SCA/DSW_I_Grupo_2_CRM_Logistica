using DSW_I_Grupo_2_CRM.DTOs;
using DSW_I_Grupo_2_CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSW_I_Grupo_2_CRM.Controllers.Api
{
    [ApiController]
    [Route("api/auth")]
    public class AccountApiController : ControllerBase
    {
        private readonly AccountService _service;
        public AccountApiController(AccountService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _service.LoginAsync(dto);

            if (usuario == null)
                return Unauthorized(new { message = "Credenciales incorrectas" });

            return Ok(new
            {
                token = usuario.Token
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.RegisterAsync(dto);

            return Ok(new { message = "Usuario registrado correctamente" });
        }
    }
}

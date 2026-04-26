using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DSW_I_Grupo_2_CRM.Data.Repositories;
using DSW_I_Grupo_2_CRM.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace DSW_I_Grupo_2_CRM.Services
{
    public class AccountService
    {
        private readonly AccountRepository repo;
        private readonly IConfiguration config;

        public AccountService(AccountRepository repo, IConfiguration config)
        {
            this.repo = repo;
            this.config = config;
        }

        public string GenerarToken(UsuarioResponseDto usuario)
        {
            var claims = new[]
            {
                new Claim("id", usuario.IdUsuario.ToString())
            };

            var key = config["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));

            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UsuarioResponseDto?> LoginAsync(UsuarioLoginDto loginDto)
        {
            var usuario = await repo.LoginAsync(loginDto);

            if (usuario == null)
                return null;

            usuario.Token = GenerarToken(usuario);

            return usuario;
        }

        public async Task RegisterAsync(UsuarioCreateDto dto)
        {
            await repo.RegisterAsync(dto);
        }

    }
}

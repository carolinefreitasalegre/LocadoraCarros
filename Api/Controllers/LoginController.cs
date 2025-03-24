using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dtos.Request.RequestLogin;
using Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest adm)
        {
            var user = await _context.admin.FirstOrDefaultAsync(a => a.Email == adm.Email);

            if (user == null)
                return BadRequest("Usuário não encontrado");


            if (adm.Email == user.Email && adm.Password == user.Password)
            {
                var token = GerarTokenJwt();
                return Ok(new { token });
            }

            return BadRequest("Senha ou email inválidos.");
        }

        private string GerarTokenJwt()
        {
            string TokenSecreto = "a086c60e-bfc2-43b6-8b9c-29cf85042522";
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecreto));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "adm"),
                new Claim("nome", "Administrador do Sistema")
            };

            var token = new JwtSecurityToken(
                issuer: "api_locadora",
                audience: "api",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectRSP.Shared.DTOs;
using ProjectRSP.Shared.Requests;
using ProjetoRSP.Infra;

namespace ProjectRSP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ProjectRSPContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthController(ProjectRSPContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var pessoa = _context
                .Pessoas
                .Where(x => x.Email == request.Email && x.Senha == request.Senha)
                .Select(x => new
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        Senha = x.Senha,
                        Role = x.PessoaRoles.FirstOrDefault().Role.Name ?? "user"
                    })
                .FirstOrDefault();
            
            if  (pessoa is null)
                return BadRequest(new {message = "Email ou senha incorretos."});
            
            var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", pessoa.Id.ToString()),
                    new Claim(ClaimTypes.Role, pessoa.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5), //token will expires 5 minutes after be created
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(new
            {
                Id = pessoa.Id,
                Token = token
            });
        }
    }
}
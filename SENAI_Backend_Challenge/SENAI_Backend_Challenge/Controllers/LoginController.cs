using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SENAI_Backend_Challenge.Domains.User.Interfaces;
using SENAI_Backend_Challenge.ViewModels.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SENAI_Backend_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginInput input)
        {
            try
            {
                var userDb = await _userRepository.GetUserLogin(input.Email, input.Password);

                if (userDb == null)
                    return NotFound("Usuário não existe ou Email/Senha inválidos.");

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, userDb.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, userDb.Id.ToString()),

                    new Claim(JwtRegisteredClaimNames.UniqueName, userDb.Name)

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai_backend_challenges-key-auth"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "SENAI_Backend_Challenge",
                    audience: "SENAI_Backend_Challenge",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception)
            {
                return StatusCode(500, "Houve um erro interno ao fazer login do usuário.");
            }
        }
    }
}

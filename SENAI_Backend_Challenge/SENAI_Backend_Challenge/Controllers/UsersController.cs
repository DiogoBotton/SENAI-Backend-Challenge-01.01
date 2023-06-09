using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Backend_Challenge.Domains.User;
using SENAI_Backend_Challenge.Domains.User.Interfaces;
using SENAI_Backend_Challenge.ViewModels.User;

namespace SENAI_Backend_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] UserInput input)
        {
            try
            {
                // Monta objeto usuario
                User newUser = new User(input.Name, input.Email, input.Password);

                // Cria usuário no bd
                var result = await _userRepository.CreateAsync(newUser);

                // Salva dados no bd
                await _userRepository.UnitOfWork.SaveDbChanges();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao criar um novo usuário");
            }
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // Retorna todos os usuários
                return Ok(await _userRepository.GetAllAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao criar um novo usuário");
            }
        }
    }
}

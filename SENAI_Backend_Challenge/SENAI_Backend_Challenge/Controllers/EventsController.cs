using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_Backend_Challenge.Domains.Event;
using SENAI_Backend_Challenge.Domains.Event.Interfaces;
using SENAI_Backend_Challenge.Domains.User;
using SENAI_Backend_Challenge.Domains.User.Interfaces;
using SENAI_Backend_Challenge.ViewModels.Event;
using SENAI_Backend_Challenge.ViewModels.User;

namespace SENAI_Backend_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly IUserRepository _userRepository;

        public EventsController(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] EventInput input)
        {
            try
            {
                var userDb = _userRepository.GetById(input.UserId);

                if (userDb == null)
                    return NotFound("Este usuário não existe, portanto, não foi possível criar o evento.");

                // Monta objeto evento
                Event newEvent = new Event(input.Name, input.NumberParticipants, input.DateOfEvent, input.HoursDuration, userDb.Id);

                // Cria usuário no bd
                var result = await _eventRepository.CreateAsync(newEvent);

                // Salva dados no bd
                await _eventRepository.UnitOfWork.SaveDbChanges();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno ao criar um novo usuário");
            }
        }
    }
}

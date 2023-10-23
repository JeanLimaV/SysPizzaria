using Microsoft.AspNetCore.Mvc;
using SysPizzaria.Application.DTOs;
using SysPizzaria.Application.Services.Interfaces;

namespace SysPizzaria.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        [Route("/teste/Create")]
        public async Task<IActionResult> Add([FromBody] PersonDTO personDto)
        {
            var person = await _personService.CreateAsync(personDto);
            return Ok(person);
        }
    }
}

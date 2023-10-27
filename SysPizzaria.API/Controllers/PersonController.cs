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
        [Route("/API/Person/Create")]
        public async Task<IActionResult> Create([FromBody] PersonDTO personDto)
        {
            var person = await _personService.CreateAsync(personDto);
            return Ok(person);
        }
        
        [HttpPut]
        [Route("/API/Person/Update")]
        public async Task<IActionResult> Update([FromBody] PersonDTO personDto)
        {
            var person = await _personService.UpdateAsync(personDto);
            return Ok(person);
        }

        [HttpDelete]
        [Route("/API/Person/Delete")]
        public async Task<IActionResult> Delete([FromBody] PersonDTO personDto)
        {
            await _personService.DeleteAsync(personDto);
            return NoContent();
        }

        [HttpGet]
        [Route("/API/Person/Get-Person")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetById(id);
            return Ok(person);
        }

        [HttpGet]
        [Route("/API/Person/Get-People")]
        public async Task<IActionResult> GetPeople()
        {
            var allPeople = await _personService.GetPeople();
            return Ok(allPeople);
        }
    }
}

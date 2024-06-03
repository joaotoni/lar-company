using Microsoft.AspNetCore.Mvc;
using TecnicExam.Models;
using TecnicExam.Services;
using System.Collections.Generic;

namespace TecnicExam.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<ApiResponse<IEnumerable<Person>>> Get()
        {
            var persons = _personService.GetAll();
            var response = new ApiResponse<IEnumerable<Person>>("ok", persons);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<ApiResponse<Person?>> Get(string id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound(new ApiResponse<Person?>("error", null));
            }
            var response = new ApiResponse<Person?>("ok", person);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ApiResponse<Person>> Post(PersonDTO personDto)
        {
            var person = new Person
            {
                Name = personDto.Name,
                CPF = personDto.CPF,
                DateOfBirth = personDto.DateOfBirth,
                active = personDto.active,
                Phones = personDto.Phones // Adicionado
            };

            _personService.Add(person);
            var response = new ApiResponse<Person>("ok", person);
            return CreatedAtAction(nameof(Get), new { id = person.Id.ToString() }, response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, PersonDTO personDto)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound(new ApiResponse<Person?>("error", null));
            }

            if (person.Phones == null)
            {
                person.Phones = new List<PhoneDetails>();
            }

            person.Phones.AddRange(personDto.Phones);

            _personService.Update(person);
            var response = new ApiResponse<Person>("ok", person);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound(new ApiResponse<Person?>("error", null));
            }

            _personService.Delete(id);
            return NoContent();
        }
    }
}

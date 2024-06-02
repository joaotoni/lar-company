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
        public IEnumerable<Person> Get()
        {
            return _personService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }

        [HttpPost]
        public ActionResult<Person> Post(PersonDTO personDto)
        {
            var person = new Person
            {
                Name = personDto.Name,
                CPF = personDto.CPF,
                DateOfBirth = personDto.DateOfBirth,
                active = personDto.active,
                PhoneType = personDto.PhoneType,
                PhoneNumber = personDto.PhoneNumber
            };

            _personService.Add(person);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, PersonDTO personDto)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            person.Name = personDto.Name;
            person.CPF = personDto.CPF;
            person.DateOfBirth = personDto.DateOfBirth;
            person.active = personDto.active;
            person.PhoneType = personDto.PhoneType;
            person.PhoneNumber = personDto.PhoneNumber;

            _personService.Update(person);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }

            _personService.Delete(id);
            return NoContent();
        }
    }
}

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
        public ActionResult<Person> Post([FromBody] PersonDTO personDto)
        {
            var person = new Person
            {
                Name = personDto.Name,
                CPF = personDto.CPF,
                DateOfBirth = personDto.BirthDate,
                IsActive = personDto.IsActive,
                PhoneType = personDto.PhoneType,
                PhoneNumber = personDto.PhoneNumber
            };
            _personService.Add(person);
            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PersonDTO updatedPersonDto)
        {
            var existingPerson = _personService.GetById(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            existingPerson.Name = updatedPersonDto.Name;
            existingPerson.CPF = updatedPersonDto.CPF;
            existingPerson.DateOfBirth = updatedPersonDto.BirthDate;
            existingPerson.IsActive = updatedPersonDto.IsActive;
            existingPerson.PhoneType = updatedPersonDto.PhoneType;
            existingPerson.PhoneNumber = updatedPersonDto.PhoneNumber;

            _personService.Update(existingPerson);
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

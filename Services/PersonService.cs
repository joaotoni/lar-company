using TecnicExam.Models;
using System.Collections.Generic;
using System.Linq;

namespace TecnicExam.Services
{
    public class PersonService : IPersonService
    {
        private readonly List<Person> _persons = new();

        public IEnumerable<Person> GetAll()
        {
            return _persons;
        }

        public Person GetById(int id)
        {
            return _persons.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Person person)
        {
            person.Id = _persons.Count > 0 ? _persons.Max(p => p.Id) + 1 : 1;
            _persons.Add(person);
        }

        public void Update(Person person)
        {
            var existingPerson = _persons.FirstOrDefault(p => p.Id == person.Id);
            if (existingPerson != null)
            {
                existingPerson.Name = person.Name;
                existingPerson.CPF = person.CPF;
                existingPerson.DateOfBirth = person.DateOfBirth;
                existingPerson.IsActive = person.IsActive;
                existingPerson.PhoneType = person.PhoneType;
                existingPerson.PhoneNumber = person.PhoneNumber;
            }
        }

        public void Delete(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _persons.Remove(person);
            }
        }
    }
}

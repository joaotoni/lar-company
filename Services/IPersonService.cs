using TecnicExam.Models;
using System.Collections.Generic;

namespace TecnicExam.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person GetById(string id); 
        void Add(Person person);
        void Update(Person person);
        void Delete(string id); 
    }
}

using TecnicExam.Models;

namespace TecnicExam.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        void Add(Person person);
        void Update(Person person);
        void Delete(int id);
    }
}

using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.Extensions.Options;
using TecnicExam.Models;
using System.Collections.Generic;

namespace TecnicExam.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMongoCollection<Person> _persons;

        public PersonService(IOptions<DatabaseSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _persons = database.GetCollection<Person>(nameof(Person));
        }

        public IEnumerable<Person> GetAll()
        {
            return _persons.Find(person => true).ToList();
        }

        public Person GetById(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("Invalid ObjectId format", nameof(id));
            }
            return _persons.Find<Person>(person => person.Id == id).FirstOrDefault();
        }

        public void Add(Person person)
        {
            _persons.InsertOne(person);
        }

        public void Update(Person person)
        {
            _persons.ReplaceOne(p => p.Id == person.Id, person);
        }

        public void Delete(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new ArgumentException("Invalid ObjectId format", nameof(id));
            }
            _persons.DeleteOne(person => person.Id == id);
        }
    }
}

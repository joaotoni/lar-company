using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace TecnicExam.Models
{
    public class PhoneDetails
    {
        public string Number { get; set; } = string.Empty;
        public string ContactType { get; set; } = string.Empty;
    }

    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string active { get; set; } = string.Empty;
        public List<PhoneDetails> Phones { get; set; } = new List<PhoneDetails>();
    }
}

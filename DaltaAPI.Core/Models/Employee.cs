using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DaltaAPI.Core.Models
{
    public class Employee : Person
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid UUID { get; set; }
        public List<string> Roles { get; set; }
        public bool Coach { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Class> Classes { get; set; }
    }
}
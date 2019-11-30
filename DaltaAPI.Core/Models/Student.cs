using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DaltaAPI.Core.Models
{
    public class Student : Person
    {
        [BsonId]
        public ObjectId StudentUUID { get; set; }
        public Employee Coach { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Class> Classes { get; set; }
    }
}
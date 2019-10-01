using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaltaAPI.Core.Models
{
    public class Grade
    {
        [BsonId]
        public string Id { get; set; }
        
        public List<ClassGrade> grades { get; set; }
    }
}
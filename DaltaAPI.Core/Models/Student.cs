using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace DaltaAPI.Core.Models
{
    public class Student : Person
    {
        public Guid UUID { get; set; }
        public Employee Coach { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Class> Classes { get; set; }
    }
}
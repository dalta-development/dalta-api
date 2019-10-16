using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaltaAPI.Core.Models
{
    public class School
    {
        public Guid UUID { get; set; }
        public string Address { get; set; }
        public List<Student> Students { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
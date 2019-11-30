using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace DaltaAPI.Core.Models
{
    public class Class
    {
        public ObjectId ClassUUID { get; set; }
        public Employee Teacher { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Homework { get; set; }
        public string Room { get; set; }
        public string Cluster { get; set; }
    }
}
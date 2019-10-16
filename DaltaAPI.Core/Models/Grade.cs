using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaltaAPI.Core.Models
{
    public class Grade
    {
        public Guid StudentUUID;
        public Guid ClassUUID;
        public Guid SchoolUUID;
        
        public List<MarkItem> Marks { get; set; }
    }

    public class MarkItem
    {
        public float Mark { get; set; }
        public short Weight { get; set; }
        public string SubjectID { get; set; }
    }
}
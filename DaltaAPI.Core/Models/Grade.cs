using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DaltaAPI.Core.Models
{
    public class Grade
    {
        [BsonId]
        public ObjectId StudentUUID;
        public ObjectId ClassUUID;
        public ObjectId SchoolUUID;
        
        public List<MarkItem> Marks { get; set; }
    }

    public class MarkItem
    {
        public float Mark { get; set; }
        public short Weight { get; set; }
        [BsonId]
        public ObjectId SubjectID { get; set; }
    }
}
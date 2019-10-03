using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DaltaAPI.Core.Models
{
    public class Grade
    {
        [BsonRepresentation(BsonType.String)]
        public string StudentUUID;
        [BsonRepresentation(BsonType.String)]
        public string ClassUUID;
        [BsonRepresentation(BsonType.String)]
        public string SchoolUUID;
        
        public List<MarkItem> Marks { get; set; }
    }

    public class MarkItem
    {
        public float Mark { get; set; }
        public short Weight { get; set; }
        public string SubjectID { get; set; }
    }
}
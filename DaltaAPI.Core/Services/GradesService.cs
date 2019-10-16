using System;
using System.Collections.Generic;
using DaltaAPI.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DaltaAPI.Core.Services
{
    public class GradesService
    {
        private readonly IMongoCollection<Grade> _grades;
        public GradesService(IDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _grades = database.GetCollection<Grade>(settings.GradesCollectionName);
        }

        public List<Grade> Get() =>
            _grades.Find(null).ToList();

        public Grade GetByUUID(ObjectId studentUuid) =>
            _grades.Find<Grade>(grade => grade.StudentUUID == studentUuid).FirstOrDefault();

        public Grade Create(Grade grade)
        {
            _grades.InsertOne(grade);
            return grade;
        }

        public void UpdateOne(Grade gradeIn, ObjectId studentUuid)
        {
            _grades.ReplaceOne(grade => grade.StudentUUID == studentUuid, gradeIn);
        }

        public void Delete(Grade gradeIn)
        {
            _grades.DeleteOne(grade => grade.StudentUUID == gradeIn.StudentUUID);
        }

        public void DeleteById(ObjectId studentUuid)
        {
            _grades.DeleteOne(grade => grade.StudentUUID == studentUuid);
        }
    }
}
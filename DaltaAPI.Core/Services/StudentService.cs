using System.Collections.Generic;
using DaltaAPI.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DaltaAPI.Core.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;
        public StudentService(IDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Student>(settings.StudentsCollectionName);
        }

        public List<Student> Get() =>
            _students.Find(null).ToList();

        public Student GetByUUID(ObjectId studentUuid) =>
            _students.Find<Student>(student => student.StudentUUID == studentUuid).FirstOrDefault();

        public Student Create(Student student)
        {
            _students.InsertOne(student);
            return student;
        }

        public void UpdateOne(Student studentIn, ObjectId studentUuid)
        {
            _students.ReplaceOne(student => student.StudentUUID == studentUuid, studentIn);
        }

        public void Delete(Student studentIn)
        {
            _students.DeleteOne(student => student.StudentUUID == studentIn.StudentUUID);
        }

        public void DeleteById(ObjectId studentUuid)
        {
            _students.DeleteOne(student => student.StudentUUID == studentUuid);
        }
    }
}
using System.Collections.Generic;
using DaltaAPI.Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DaltaAPI.Core.Services
{
    public class SchoolService
    {
        private readonly IMongoCollection<School> _schools;
        public SchoolService(IDatabaseSettings settings)
        {
            MongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(settings.DatabaseName);

            _schools = database.GetCollection<School>(settings.SchoolsCollectionName);
        }

        public List<School> Get() =>
            _schools.Find(null).ToList();

        public School GetByUUID(ObjectId schoolUuid) =>
            _schools.Find<School>(school => school.SchoolUUID == schoolUuid).FirstOrDefault();

        public School Create(School school)
        {
            _schools.InsertOne(school);
            return school;
        }

        public void UpdateOne(School schoolIn, ObjectId schoolUuid)
        {
            _schools.ReplaceOne(school => school.SchoolUUID == schoolUuid, schoolIn);
        }

        public void Delete(School schoolIn)
        {
            _schools.DeleteOne(school => school.SchoolUUID == schoolIn.SchoolUUID);
        }

        public void DeleteById(ObjectId schoolUuid)
        {
            _schools.DeleteOne(school => school.SchoolUUID == schoolUuid);
        }
    }
}
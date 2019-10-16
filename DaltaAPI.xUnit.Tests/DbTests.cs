using System;
using Bogus;
using DaltaAPI.Core.Models;
using DaltaAPI.Core.Services;
using MongoDB.Bson;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace DaltaAPI.xUnit.Tests
{
    public class DbTests
    {
        private readonly DatabaseSettings _settings = new DatabaseSettings();
        private readonly ITestOutputHelper _output;
        
        public DbTests(ITestOutputHelper helper)
        {
            _settings.ConnectionString = "mongodb://localhost:27017";
            _settings.DatabaseName = "DaltaDB";
            _settings.GradesCollectionName = "Grades";
            _output = helper;
        }
        
        [Fact]
        public void FillAndSaveGradeToDB()
        {
            var testMarks = new Faker<MarkItem>()
                .StrictMode(true)
                .RuleFor(o => o.Mark, f => f.Random.Float())
                .RuleFor(o => o.Weight, f => f.Random.Short())
                .RuleFor(o => o.SubjectID, f => ObjectId.GenerateNewId());
            
            var testGrade = new Faker<Grade>()
                .StrictMode(true)
                .RuleFor(o => o.StudentUUID, f => ObjectId.GenerateNewId())
                .RuleFor(o => o.SchoolUUID, f => ObjectId.GenerateNewId())
                .RuleFor(o => o.ClassUUID, f => ObjectId.GenerateNewId())
                .RuleFor(o => o.Marks, f => testMarks.Generate(5));
            
            GradesService gradesService = new GradesService(_settings);

            Grade generatedGrade = testGrade.Generate();
            _output.WriteLine(generatedGrade.ToJson());
            Assert.True(gradesService.Create(generatedGrade) != null);
            //gradesService.Delete(generatedGrade);
        }
    }
}
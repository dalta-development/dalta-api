using System;
using System.Linq;
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
            _settings.StudentsCollectionName = "Students";
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
            gradesService.Delete(generatedGrade);
        }

        [Fact]
        public void FillAndSaveStudentToDB()
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
            
            var testClass = new Faker<Class>()
                .StrictMode(true)
                .RuleFor(o => o.ClassUUID, f => ObjectId.GenerateNewId())
                .RuleFor(o => o.Subject, f => f.Vehicle.Manufacturer())
                .RuleFor(o => o.StartTime, f => f.Date.Recent())
                .RuleFor(o => o.EndTime, f => f.Date.Future())
                .RuleFor(o => o.Homework, f => f.Lorem.Text())
                .RuleFor(o => o.Room, f => f.Random.Int().ToString())
                .RuleFor(o => o.Cluster, f => f.Random.Int().ToString());
            
            var testEmployee = new Faker<Employee>()
                .StrictMode(true)
                .RuleFor(o => o.EmployeeUUID, f => ObjectId.GenerateNewId())
                .RuleFor(o => o.Roles, f => f.Make(4, () => f.Company.Bs()))
                .RuleFor(o => o.Coach, f => f.Random.Bool())
                .RuleFor(o => o.BirthDate, f => f.Date.Future())
                .RuleFor(o => o.Classes, f => testClass.Generate(10))
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber());

            testClass.RuleFor(o => o.Teacher, f => testEmployee.Generate());

            var testStudent = new Faker<Student>()
                .StrictMode(true)
                .RuleFor(o => o.StudentUUID, f => ObjectId.GenerateNewId())
                .RuleFor(o => o.Coach, f => testEmployee.Generate())
                .RuleFor(o => o.BirthDate, f => f.Date.Past())
                .RuleFor(o => o.Grades, f => testGrade.Generate(10))
                .RuleFor(o => o.Classes, f => testClass.Generate(10))
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Address, f => f.Address.FullAddress())
                .RuleFor(o => o.PhoneNumber, f => f.Phone.PhoneNumber());
            
            StudentService studentService = new StudentService(_settings);
            
            Student generatedStudent = testStudent.Generate();
            //_output.WriteLine(generatedStudent.ToJson());
            Assert.True(studentService.Create(generatedStudent) != null);
            //studentService.Delete(generatedStudent);
        }
    }
}
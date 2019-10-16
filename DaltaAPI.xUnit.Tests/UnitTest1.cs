using System;
using Bogus;
using DaltaAPI.Core.Models;
using Xunit;

namespace DaltaAPI.xUnit.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FillAndSaveGradeToDB()
        {
            var testMarks = new Faker<MarkItem>()
                .StrictMode(true)
                .RuleFor(o => o.Mark, f => f.Random.Float())
                .RuleFor(o => o.Weight, f => f.Random.Int())
                .RuleFor(o => o.SubjectID, f => new Guid().ToString());
            
            var testGrade = new Faker<Grade>()
                .StrictMode(true)
                .RuleFor(o => o.StudentUUID, f => Guid.NewGuid())
                .RuleFor(o => o.SchoolUUID, f => new Guid().ToString())
                .RuleFor(o => o.ClassUUID, f => new Guid().ToString())
                .RuleFor(o => o.Marks, f => testMarks.Generate(5));
            
            Assert.True(testGrade.Generate(1) != null);
        }
    }
}
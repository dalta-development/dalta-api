using System;
using Bogus;
using DaltaAPI.Core.Models;
using DaltaAPI.Core.Services;
using Xunit;

namespace DaltaAPI.xUnit.Tests
{
    public class DbTests
    {
        [Fact]
        public void FillAndSaveGradeToDB()
        {
            var testMarks = new Faker<MarkItem>()
                .StrictMode(true)
                .RuleFor(o => o.Mark, f => f.Random.Float())
                .RuleFor(o => o.Weight, f => f.Random.Short())
                .RuleFor(o => o.SubjectID, f => new Guid().ToString());
            
            var testGrade = new Faker<Grade>()
                .StrictMode(true)
                .RuleFor(o => o.StudentUUID, f => Guid.NewGuid())
                .RuleFor(o => o.SchoolUUID, f => Guid.NewGuid())
                .RuleFor(o => o.ClassUUID, f => Guid.NewGuid())
                .RuleFor(o => o.Marks, f => testMarks.Generate(5));
            
            
            
            Assert.True(testGrade.Generate() != null);
        }
    }
}
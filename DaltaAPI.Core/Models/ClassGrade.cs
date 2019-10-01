using System.Collections.Generic;

namespace DaltaAPI.Core.Models
{
    public class ClassGrade
    {
        public string Name { get; set; }
        public List<KeyValuePair<float, int>> Grades { get; set; }
    }
}
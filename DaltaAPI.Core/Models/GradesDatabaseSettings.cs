namespace DaltaAPI.Core.Models
{
    public class GradesDatabaseSettings : IGradesDatabaseSettings
    {
        public string GradesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    
    public interface IGradesDatabaseSettings
    {
        string GradesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
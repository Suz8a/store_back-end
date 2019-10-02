namespace TroquelApi.Models
{
    public class TroquelDatabaseSettings : ITroquelDatabaseSettings
    {
        public string TroquelCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ITroquelDatabaseSettings
    {
        string TroquelCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

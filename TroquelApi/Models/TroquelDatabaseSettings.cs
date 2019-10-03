namespace TroquelApi.Models
{
    public class TroquelDatabaseSettings : ITroquelDatabaseSettings
    {
        public string ClienteCollectionName { get; set; }
        public string JoyaCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ITroquelDatabaseSettings
    {
        string ClienteCollectionName { get; set; }
        string JoyaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

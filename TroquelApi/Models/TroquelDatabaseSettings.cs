namespace TroquelApi.Models
{
    public class TroquelDatabaseSettings : ITroquelDatabaseSettings
    {
        public string ClienteCollectionName { get; set; }
        public string JoyaCollectionName { get; set; }
        public string RolCollectionName { get; set; }
        public string ServicioCollectionName { get; set; }
        public string EstadoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ITroquelDatabaseSettings
    {
        string ClienteCollectionName { get; set; }
        string JoyaCollectionName { get; set; }
        string RolCollectionName { get; set; }
        string ServicioCollectionName { get; set; }
        string EstadoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

namespace TodoManager.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConnectionString
        {
            get
            {
                return $"mongodb://{Username}:{Password}@{Host}:{Port}";
            }
        }
    }
}
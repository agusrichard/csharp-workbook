namespace TodoManager.Settings
{
    public class DbSettings
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string DbConnectionString
        {
            get
            {
                return $"Server={Host},{Port};Database={Name};User Id={Username};Password={Password};";
            }
        }
    }
}
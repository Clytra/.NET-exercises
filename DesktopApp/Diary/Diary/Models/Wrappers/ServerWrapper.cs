using Diary.Properties;

namespace Diary.Models.Wrappers 
{
    public static class ServerWrapper 
    {
        public static string ServerAddress
        {
            get
            {
                return Settings.Default.ServerAddress;
            }
            set
            {
                Settings.Default.ServerAddress = value;
            }
        }
        public static string ServerName
        {
            get
            {
                return Settings.Default.ServerName;
            }
            set
            {
                Settings.Default.ServerName = value;
            }
        }
        public static string DbName
        {
            get
            {
                return Settings.Default.DbName;
            }
            set
            {
                Settings.Default.DbName = value;
            }
        }
        public static string UserName
        {
            get
            {
                return Settings.Default.UserName;
            }
            set
            {
                Settings.Default.UserName = value;
            }
        }
        public static string Password
        {
            get
            {
                return Settings.Default.Password;
            }
            set
            {
                Settings.Default.Password = value;
            }
        }

        public static string GetConnectionString()
        {
            return $"Server={ServerName};Database={DbName};User Id={UserName};Password={Password};";
        }
    }
}

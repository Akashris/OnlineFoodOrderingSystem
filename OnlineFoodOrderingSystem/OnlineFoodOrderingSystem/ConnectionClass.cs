namespace OnlineFoodOrderingSystem
{

    class ConnectionClass
    {
        public static string GetConnection()
        {
            string server = System.Configuration.ConfigurationSettings.AppSettings["Servername"].ToString();
            string uname = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
            string password = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
            string db = System.Configuration.ConfigurationSettings.AppSettings["Database"].ToString();
            return string.Format(@"Data Source={0};initial catalog={1};user id={2};password={3}", server, db, uname, password);
        }
    }
}

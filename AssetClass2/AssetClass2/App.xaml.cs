using System.Configuration;
using System.Data;
using System.Windows;

namespace AssetClass2
{
    
    public partial class App : Application
    {
        // below code is used throughout the application for connection to the database
        public static string ConnectionString { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConnectionString = "Server = localhost; Database = assetclassanalyzer; uid = root; Pwd = password;"; //information that is used to establish connection with appropriate database
        }

    }

}

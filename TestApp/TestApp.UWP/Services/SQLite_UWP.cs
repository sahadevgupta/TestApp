using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Interfaces;
using TestApp.UWP.Services;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace TestApp.UWP.Services
{
    public class SQLite_UWP : IDBInterface
    {
        public SQLiteConnection conn;
        public SQLite_UWP()
        {
             
        }

        public SQLiteConnection GetConnection()
        {
           
            return conn;
        }

        void IDBInterface.InitializeDB()
        {
            string filename = "TestApp.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            conn = new SQLite.SQLiteConnection(path);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using SQLite;
using TestApp.Interfaces;
using TestApp.iOS.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOs))]
namespace TestApp.iOS.Services
{
    public class SQLite_iOs : IDBInterface
    {
        SQLiteConnection conn;
        public SQLiteConnection GetConnection()
        {
           
            return conn;
        }

        public void InitializeDB()
        {
            string filename = "TestApp.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), filename);
            conn = new SQLite.SQLiteConnection(path);
        }
    }
}
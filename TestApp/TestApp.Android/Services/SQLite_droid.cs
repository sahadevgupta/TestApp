using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TestApp.Droid.Services;
using TestApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_droid))]
namespace TestApp.Droid.Services
{
    public class SQLite_droid : IDBInterface
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
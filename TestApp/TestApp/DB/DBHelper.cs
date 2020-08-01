using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp.Interfaces;
using TestApp.Models;
using Xamarin.Forms;

namespace TestApp.DB
{
    public static class DBHelper
    {
        public static SQLiteConnection sqlConnection;

        public static void InitializeMainDatabase()
        {

            var dBInterface = DependencyService.Get<IDBInterface>();
            dBInterface.InitializeDB();

            sqlConnection = dBInterface.GetConnection();
            var databaseInfo = sqlConnection.GetTableInfo(nameof(UserInfo));
            if (!databaseInfo.Any())
            {
                sqlConnection.CreateTable<UserInfo>();
            }
           
        }
    }
}

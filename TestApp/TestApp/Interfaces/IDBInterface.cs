using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Interfaces
{
    public interface IDBInterface
    {
        SQLiteConnection GetConnection();
        void InitializeDB();
    }
}

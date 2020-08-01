using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Models
{
    public class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
    }
}

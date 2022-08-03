using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Eats.Data
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public bool Roles { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string CellPhone { get; set; }
    }
}

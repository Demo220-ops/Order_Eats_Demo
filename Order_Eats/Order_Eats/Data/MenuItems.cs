using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Order_Eats.Data
{
    public class MenuItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string DishName { get; set; }

        public string Description { get; set; }

        public string category { get; set; }

        public string DishPrice { get; set; }

    }
}

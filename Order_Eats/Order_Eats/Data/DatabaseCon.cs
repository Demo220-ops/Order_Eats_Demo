using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order_Eats.Data
{
    public class DatabaseCon
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseCon(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MenuItems>();

            _database.CreateTableAsync<Users>();
        }


        public Task<List<MenuItems>> GetRecipeAsync(string cat)
        {
            return _database.Table<MenuItems>().Where(t => t.category == cat).ToListAsync();

        }

        //CRUD Operations

        //Insert recipe in database
        public Task<int> SaveRecipeAsync(MenuItems menuItem)
        {
            return _database.InsertAsync(menuItem);
        }

        //Update recipe in database
        public Task<int> UpdateRecipeAsync(MenuItems menuItem)
        {
            return _database.UpdateAsync(menuItem);
        }

        //Delete recipe in database
        public Task<int> DeleteRecipeAsync(MenuItems menuItem)
        {
            return _database.DeleteAsync(menuItem);
        }


        //UserData 
        
        //get user data
        public Task<List<Users>> GetUserAsync()
        {
            return _database.Table<Data.Users>().ToListAsync();

        }

        //save users to the database
        public Task<int> SaveUserAsync(Users user)
        {
            return _database.InsertAsync(user);
        }

        //updating the user data
        public Task<int> UpdateUserAsync(Users user)
        {
            return _database.UpdateAsync(user);
        }

        //Deleting the user data
        public Task<int> DeleteUserAsync(Users user)
        {
            return _database.DeleteAsync(user);
        }

    }
}

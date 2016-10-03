using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Autowont.Models;

namespace Autowont.Services
{
    public class DatabaseService
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
        /// if the database doesn't exist, it will create the database and all the tables.
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        public DatabaseService()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<JsonAdvMosel>();
            //database.CreateTable<HitorySearchModel>();
        }

        public IEnumerable<JsonAdvMosel> GetItems()
        {
            lock (locker)
            {
                return (from i in database.Table<JsonAdvMosel>() select i).ToList();
            }
        }

        
        public JsonAdvMosel GetItem(int id)
        {
            lock (locker)
            {
                return database.Table<JsonAdvMosel>().FirstOrDefault(x => x.ID == id);
            }
        }

        public int SaveItem(JsonAdvMosel item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<JsonAdvMosel>(id);
            }
        }
    }
}

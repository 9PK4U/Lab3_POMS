using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using Lab3_POMS.Classes.Lab4;
using Xamarin.Essentials;

namespace Lab3_POMS.Classes
{
    
    public class DataBase
    {
        SQLiteConnection database;

        public DataBase()
        {
            //var path = Preferences.Get()
            var path = Preferences.Get("PATH_DATABASE", "EMPTY");
            if (path == "EMPTY")
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataBase.db");
                Preferences.Set("PATH_DATABASE", path);
            }
            database = new SQLiteConnection(path);
            database.CreateTable<HistoryItem>();
        }

        public IEnumerable<HistoryItem> GetHistoryItems()
        {
            return database.Table<HistoryItem>().ToList();
        }
        public int AddItem(HistoryItem item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
        public void remove()
        {
            database.DeleteAll<HistoryItem>();
        }
    }
}

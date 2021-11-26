using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace T2009M1NguyenCuongUWP.Data
{
    public class DatabaseContact
    {
        private static string _databaseFile = "mycontact.db";
        public static string _databasePath;
        private static string _createContactTable = "CREATE TABLE IF NOT EXISTS contacts " +
            "(PhoneNumber INTEGER NOT NULL," +
            "Name NVARCHAR(255) NOT NULL)";

        public async static void UpDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(_databaseFile, CreationCollisionOption.OpenIfExists);
            _databasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, _databaseFile);
            using (SqliteConnection cnn = new SqliteConnection($"Filename = {_databasePath}"))
            {
                cnn.Open();
                SqliteCommand createTableNote = new SqliteCommand(_createContactTable, cnn);
                createTableNote.ExecuteNonQuery();
            }
        }
    }
}

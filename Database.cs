using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteApp
{
    class Database
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db")) //สร้างไฟล์ชื่อ sqliteSample.db
            {
                db.Open(); //สั่งเปิด
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS MyTable (Primary_Key INTEGER PRIMARY KEY, " +
                    "Text_Entry NVARCHAR(2048) NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader(); //สั่งรัน
            }
        }
        public static void AddData(string inputText)
        {
            using (SqliteConnection db =
              new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "INSERT INTO MyTable VALUES (NULL, @Name);";
                insertCommand.Parameters.AddWithValue("@Name", inputText);

                insertCommand.ExecuteReader();

                db.Close();
            }
        }
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Text_Entry from MyTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }

                db.Close();

            }
            return entries;
        }
    }
}

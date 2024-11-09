using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace LabIntakeApp
{
    public class DatabaseManager
    {
        private string connectionString;

        public DatabaseManager()
        {
            // הגדרת מחרוזת חיבור לקובץ ה-SQLite המקומי
            connectionString = "Data Source=LabIntake.db";
        }

        public void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // יצירת טבלאות אם הן לא קיימות
                string createComponentsTable = @"CREATE TABLE IF NOT EXISTS Components (
                    ComponentID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClientName TEXT NOT NULL,
                    ContactPhone TEXT,
                    Purpose TEXT,
                    EntryDateTime TEXT DEFAULT CURRENT_TIMESTAMP,
                    Status TEXT DEFAULT 'פתוח'
                );";

                string createSerialsTable = @"CREATE TABLE IF NOT EXISTS Serials (
                    SerialID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ComponentID INTEGER,
                    SerialNumber TEXT NOT NULL,
                    Status TEXT DEFAULT 'נכנס',
                    FOREIGN KEY(ComponentID) REFERENCES Components(ComponentID)
                );";

                using (var command = new SqliteCommand(createComponentsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createSerialsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetComponents()
        {
            DataTable dataTable = new DataTable();
            using (var connection = new SqliteConnection(connectionString))
            {
                string query = "SELECT * FROM Components ORDER BY EntryDateTime DESC";
                using (var command = new SqliteCommand(query, connection))
                using (var adapter = new SqliteDataAdapter(command))
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        public void AddComponent(string clientName, string contactPhone, string purpose)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                string query = "INSERT INTO Components (ClientName, ContactPhone, Purpose) VALUES (@ClientName, @ContactPhone, @Purpose)";
                using (var command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClientName", clientName);
                    command.Parameters.AddWithValue("@ContactPhone", contactPhone);
                    command.Parameters.AddWithValue("@Purpose", purpose);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

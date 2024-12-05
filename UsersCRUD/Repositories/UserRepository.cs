using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using UsersCRUD.Model;


namespace UsersCRUD.Repositories
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string databasePath)
        {
            _connectionString = $"Data source={databasePath};Version=3";
            InitializeDatabase();
        }
        private void InitializeDatabase()
        {
            using (SqliteConnection conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        LastName TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );";

                using (SqliteCommand command = new SqliteCommand(createTableQuery, conn))
                {
                    command.ExecuteNonQuery();
                }
            }

        }

        public void AddUser(User user)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Users (name, lastName, email, password) VALUES (@Name, @LastName, @Email, @Password);";

                using (SqliteCommand command = new SqliteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Users;";

                using (SqliteCommand command = new SqliteCommand(selectQuery, connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Password = reader["Password"].ToString()
                        });
                    }
                }
            }

            return users;
        }

        public void UpdateUser(User user)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string updateQuery = "UPDATE Users SET name = @Name, lastName = @LastName, email = @Email, password = @Password WHERE Email = @Email;";

                using (SqliteCommand command = new SqliteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(string email)
        {
            using (SqliteConnection connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Users WHERE Email = @Email;";

                using (SqliteCommand command = new SqliteCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

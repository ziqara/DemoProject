using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DemoLib.DataModel.Users;

namespace DemoLib.Models.Users
{
    public class MySqlUsersModel : IUsersRepository
    {
        private const string connStr = "server=localhost;user=root;database=clients_db;password=1234567;port=3307;";

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            try
            {
                using (var connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT `Login`, `Password`, `Role` FROM `users`";
                    using (var command = new MySqlCommand(sql, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var u = new User
                            {
                                Login = reader.GetString(0),
                                Password = reader.GetString(1),
                                Role = MapRole(reader.GetString(2))
                            };
                            users.Add(u);
                        }
                    }
                }

                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при чтении списка пользователей из БД.", ex);
            }
        }

        public User GetUserByLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return null;

            try
            {
                using (var connection = new MySqlConnection(connStr))
                {
                    connection.Open();

                    const string sql = "SELECT `Login`, `Password`, `Role` FROM `users` WHERE `Login` = @login LIMIT 1";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Login = reader.GetString(0),
                                    Password = reader.GetString(1),
                                    Role = MapRole(reader.GetString(2))
                                };
                            }
                        }
                    }
                }

                return null; // не найден
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при поиске пользователя с логином '{login}'.", ex);
            }
        }

        private static UserRole MapRole(string roleFromDb)
        {
            // В БД: client | manager | admin; в enum: Client | Manager | Admin
            switch (roleFromDb?.Trim().ToLowerInvariant())
            {
                case "client": return UserRole.Client;
                case "manager": return UserRole.Manager;
                case "admin": return UserRole.Admin;
                default:
                    // на случай неожиданных значений — можно кинуть исключение или выбрать значение по умолчанию
                    throw new ArgumentOutOfRangeException(nameof(roleFromDb), $"Неизвестная роль: {roleFromDb}");
            }
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace z1.Services
{
    public class AuthService
    {
        private const string UsersFilePath = "users.json";

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            if (!File.Exists(UsersFilePath))
            {
                MessageBox.Show($"Файл {UsersFilePath} не найден. Создается новый файл с пользователями по умолчанию.");
                var defaultUsers = new UsersData
                {
                    Users = new List<User>
                    {
                        new User { Username = "teacher1", Password = "pass123", Role = "Teacher" },
                        new User { Username = "student1", Password = "pass456", Role = "Student" }
                    }
                };
                var json = JsonSerializer.Serialize(defaultUsers, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(UsersFilePath, json);
            }

            try
            {
                var json = await File.ReadAllTextAsync(UsersFilePath);
                var data = JsonSerializer.Deserialize<UsersData>(json);

                if (data == null || data.Users == null)
                {
                    MessageBox.Show("Ошибка: данные пользователей не загружены из файла.");
                    return null;
                }

                var user = data.Users.Find(u => u.Username == username && u.Password == password);
                return user;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении users.json: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> RegisterAsync(string username, string password, string role)
        {
            var data = await LoadUsersAsync();

            if (data.Users.Exists(u => u.Username == username))
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
                return false;
            }

            data.Users.Add(new User { Username = username, Password = password, Role = role });
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(UsersFilePath, json);
            MessageBox.Show($"Пользователь {username} успешно зарегистрирован.");
            return true;
        }

        private async Task<UsersData> LoadUsersAsync()
        {
            if (!File.Exists(UsersFilePath))
            {
                return new UsersData { Users = new List<User>() };
            }

            var json = await File.ReadAllTextAsync(UsersFilePath);
            return JsonSerializer.Deserialize<UsersData>(json) ?? new UsersData { Users = new List<User>() };
        }
    }

    public class UsersData
    {
        public List<User> Users { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
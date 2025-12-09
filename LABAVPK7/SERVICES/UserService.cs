using Microsoft.AspNetCore.Identity;
using LABAVPK7.MODELS;

namespace LABAVPK7.SERVICES
{
    public class UserService : IUserService
    {
        private static List<User> _users = new List<User>();
        private static int _nextId = 1;

        public async Task<User> RegisterAsync(RegisterRequest request)
        {
            // Проверка на существующий email
            if (_users.Any(u => u.Email == request.Email))
                throw new Exception("Пользователь с таким email уже существует");

            // Хеширование пароля (в реальном проекте используйте PasswordHasher)
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Id = _nextId++,
                Username = request.Username,
                Email = request.Email,
                PasswordHash = passwordHash
            };

            _users.Add(user);
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return _users;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
    }
}

using LABAVPK7.MODELS;

namespace LABAVPK7.SERVICES
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterRequest request);
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
    }
}
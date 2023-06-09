using SENAI_Backend_Challenge.SeedWork;

namespace SENAI_Backend_Challenge.Domains.User.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserLogin(string email, string password);
    }
}

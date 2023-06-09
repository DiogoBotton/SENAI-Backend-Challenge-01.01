using Microsoft.EntityFrameworkCore;
using SENAI_Backend_Challenge.Contexts;
using SENAI_Backend_Challenge.Domains.User;
using SENAI_Backend_Challenge.Domains.User.Interfaces;
using SENAI_Backend_Challenge.SeedWork;

namespace SENAI_Backend_Challenge.Repositories.UserRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SenaiContext ctx) : base(ctx)
        {
        }

        public async Task<User?> GetUserLogin(string email, string password)
        {
            return await _ctx.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}

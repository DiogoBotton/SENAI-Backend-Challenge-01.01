using SENAI_Backend_Challenge.SeedWork;

namespace SENAI_Backend_Challenge.Domains.User
{
    public class User : AbstractDomain
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            IsActive = true;
        }

        public void UpdateUser(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void DesactiveUser()
        {
            IsActive = false;
        }
    }
}

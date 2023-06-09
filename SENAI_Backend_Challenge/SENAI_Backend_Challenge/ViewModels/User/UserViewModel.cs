namespace SENAI_Backend_Challenge.ViewModels.User
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public UserViewModel(string name, string email, bool isActive)
        {
            Name = name;
            Email = email;
            IsActive = isActive;
        }
    }
}

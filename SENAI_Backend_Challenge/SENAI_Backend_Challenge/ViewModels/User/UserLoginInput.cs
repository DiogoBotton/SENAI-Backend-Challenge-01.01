using System.ComponentModel.DataAnnotations;

namespace SENAI_Backend_Challenge.ViewModels.User
{
    public class UserLoginInput
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

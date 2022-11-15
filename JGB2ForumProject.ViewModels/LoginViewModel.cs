using System.ComponentModel.DataAnnotations;

namespace JGB2ForumProject.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

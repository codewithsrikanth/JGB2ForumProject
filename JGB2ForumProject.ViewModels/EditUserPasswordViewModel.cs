using System.ComponentModel.DataAnnotations;

namespace JGB2ForumProject.ViewModels
{
    public class EditUserPasswordViewModel
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace JGB2ForumProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z]*$")]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }
    }
}

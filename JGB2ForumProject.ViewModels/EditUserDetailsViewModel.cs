using System.ComponentModel.DataAnnotations;

namespace JGB2ForumProject.ViewModels
{
    public class EditUserDetailsViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }
    }
}

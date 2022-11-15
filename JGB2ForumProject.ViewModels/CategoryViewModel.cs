using System.ComponentModel.DataAnnotations;

namespace JGB2ForumProject.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}

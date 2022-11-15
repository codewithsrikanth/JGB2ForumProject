using System;

namespace JGB2ForumProject.ViewModels
{
    public class EditQuestionViewModel
    {
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        public DateTime QuestionDateAndTime { get; set; }
        public int CategoryID { get; set; }
    }
}

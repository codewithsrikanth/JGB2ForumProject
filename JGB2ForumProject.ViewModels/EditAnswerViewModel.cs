using System;

namespace JGB2ForumProject.ViewModels
{
    public class EditAnswerViewModel
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public DateTime AnswerDateAndTime { get; set; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public int VotesCount { get; set; }

        public virtual QuestionViewModel Question { get; set; }
    }
}

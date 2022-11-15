using System;

namespace JGB2ForumProject.ViewModels
{
    public class NewAnswerViewModel
    {
        public string AnswerText { get; set; }
        public DateTime AnswerDateAndTime { get; set; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public int ViewsCount { get; set; }
    }
}

using System;

namespace JGB2ForumProject.ViewModels
{
    public class NewQuestionViewModel
    {
        public string QuestionName { get; set; }
        public DateTime QuestionDateAndTime { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int VotesCount { get; set; }
        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }
    }
}

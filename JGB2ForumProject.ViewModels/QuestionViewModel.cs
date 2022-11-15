using System;
using System.Collections.Generic;

namespace JGB2ForumProject.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionID { get; set; }
        public string QuestionName { get; set; }
        public DateTime QuestionDateAndTime { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public int VotesCount { get; set; }
        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }

        public UserViewModel User { get; set; }
        public CategoryViewModel Category { get; set; }

        public virtual List<AnswerViewModel> Answers { get; set; }
    }
}

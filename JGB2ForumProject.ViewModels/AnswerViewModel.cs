using System;
using System.Collections.Generic;

namespace JGB2ForumProject.ViewModels
{
    public class AnswerViewModel
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public DateTime AnswerDateAndTime { get; set; }
        public int UserID { get; set; }
        public int QuestionID { get; set; }
        public int VotesCount { get; set; }
        public int CurrentUserVoteType { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual List<VotesViewModel> Votes { get; set; }        
    }
}

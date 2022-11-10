using JGB2ForumProject.DataModels;
using System.Collections.Generic;

namespace JGB2ForumProject.RepositoryLayer.Implementation
{
    public interface IQuestionRepository
    {
        void InsertQuestion(Question q);
        void UpdateQuestionDetails(Question q);
        void UpdateQuestionVotesCount(int qid, int votecount);
        void UpdateQuestionAnswersCount(int qid, int answercount);
        void UpdateQuestionViewsCount(int qid);
        void DeleteQuestion(int qid);
        List<Question> GetAllQuestions();
        Question GetQuestionBasedonQuestionID(int qid);
    }
}

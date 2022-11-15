using JGB2ForumProject.DataModels;
using System.Collections.Generic;

namespace JGB2ForumProject.RepositoryLayer.Interfaces
{
    public interface IAnswerRepository
    {
        void InsertAnswer(Answer a);
        void UpdateAnswer(Answer a);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<Answer> GetAnswersByQuestionID(int qid);
        List<Answer> GetAnswersByAnswerID(int AnswerID);
    }
}

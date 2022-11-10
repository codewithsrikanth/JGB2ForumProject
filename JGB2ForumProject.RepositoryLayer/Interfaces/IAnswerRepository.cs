using JGB2ForumProject.DataModels;
using System.Collections.Generic;

namespace JGB2ForumProject.RepositoryLayer.Interfaces
{
    public interface IAnswerRepository
    {
        void InsertAnswer(Answer ans);
        void UpdateAnswer(Answer answer);
        void DeleteAnswer(int aid);
        List<Answer> GetAllAnswers();
        Answer GetAnswerByAnswerID(int aid);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
    }
}

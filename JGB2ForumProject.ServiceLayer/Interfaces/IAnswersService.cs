using JGB2ForumProject.ViewModels;
using System.Collections.Generic;

namespace JGB2ForumProject.ServiceLayer.Interfaces
{
    public interface IAnswersService
    {
        void InsertAnswer(NewAnswerViewModel avm);
        void UpdateAnswer(EditAnswerViewModel avm);
        void UpdateAnswerVotesCount(int aid, int uid, int value);
        void DeleteAnswer(int aid);
        List<AnswerViewModel> GetAnswersByQuestionID(int qid);
        AnswerViewModel GetAnswerByAnswerID(int AnswerID);
    }
}

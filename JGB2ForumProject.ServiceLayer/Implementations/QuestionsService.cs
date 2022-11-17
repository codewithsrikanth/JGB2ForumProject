using AutoMapper;
using JGB2ForumProject.DataModels;
using JGB2ForumProject.RepositoryLayer.Implementation;
using JGB2ForumProject.ServiceLayer.Interfaces;
using JGB2ForumProject.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace JGB2ForumProject.ServiceLayer.Implementations
{
    public class QuestionsService:IQuestionsService
    {
        IQuestionRepository qr;

        public QuestionsService()
        {
            qr = new QuestionRepository();
        }

        public void InsertQuestion(NewQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<NewQuestionViewModel, Question>(qvm);
            qr.InsertQuestion(q);
        }

        public void UpdateQuestionDetails(EditQuestionViewModel qvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditQuestionViewModel, Question>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Question q = mapper.Map<EditQuestionViewModel, Question>(qvm);
            qr.UpdateQuestionDetails(q);
        }

        public void UpdateQuestionVotesCount(int qid, int value)
        {
            qr.UpdateQuestionVotesCount(qid, value);
        }
        public void UpdateQuestionAnswersCount(int qid, int value)
        {
            qr.UpdateQuestionAnswersCount(qid, value);
        }
        public void UpdateQuestionViewsCount(int qid, int value)
        {
            qr.UpdateQuestionViewsCount(qid, value);
        }
        public void DeleteQuestion(int qid)
        {
            qr.DeleteQuestion(qid);
        }

        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> q = qr.GetAllQuestions();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Question, QuestionViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<QuestionViewModel> qvm = mapper.Map<List<Question>, List<QuestionViewModel>>(q);
            return qvm;
        }

        public QuestionViewModel GetQuestionByQuestionID(int QuestionID, int UserID = 0)
        {
            Question q = qr.GetQuestionBasedonQuestionID(QuestionID);
            QuestionViewModel qvm = null;
            if (q != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Question, QuestionViewModel>();
                    cfg.IgnoreUnmapped();
                });
                IMapper mapper = config.CreateMapper();
                qvm = mapper.Map<Question, QuestionViewModel>(q);

                foreach (var item in qvm.Answers)
                {
                    item.CurrentUserVoteType = 0;
                    VotesViewModel vote = item.Votes.Where(temp => temp.UserID == UserID).FirstOrDefault();
                    if (vote != null)
                    {
                        item.CurrentUserVoteType = vote.VoteValue;
                    }
                }
            }
            return qvm;
        }
    }
}

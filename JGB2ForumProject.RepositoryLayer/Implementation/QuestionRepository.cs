using JGB2ForumProject.DataModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace JGB2ForumProject.RepositoryLayer.Implementation
{
    public class QuestionRepository:IQuestionRepository
    {
        JGB2ForumDBContext _dbContext;
        public QuestionRepository()
        {
            _dbContext = new JGB2ForumDBContext();
        }

        public void DeleteQuestion(int qid)
        {
            _dbContext.Questions.Remove(_dbContext.Questions.Where(x => x.QuestionID == qid).FirstOrDefault());
            _dbContext.SaveChanges();
        }

        public List<Question> GetAllQuestions()
        {
            return _dbContext.Questions.ToList();
        }

        public Question GetQuestionBasedonQuestionID(int qid)
        {
            return _dbContext.Questions.Find(qid);
        }

        public void InsertQuestion(Question q)
        {
            _dbContext.Questions.Add(q);
            _dbContext.SaveChanges();
        }

        public void UpdateQuestionAnswersCount(int qid, int answercount)
        {
            Question question = _dbContext.Questions.Find(qid);
            if(question != null)
            {
                question.AnswersCount += answercount;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateQuestionDetails(Question q)
        {
            _dbContext.Entry(q).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void UpdateQuestionViewsCount(int qid)
        {
            Question question = _dbContext.Questions.Find(qid);
            if (question != null)
            {
                question.ViewsCount += 1;
                _dbContext.SaveChanges();
            }
        }

        public void UpdateQuestionVotesCount(int qid, int votecount)
        {
            Question question = _dbContext.Questions.Find(qid);
            if(question != null)
            {
                question.VotesCount += votecount;
                _dbContext.SaveChanges();
            }
        }
    }
}

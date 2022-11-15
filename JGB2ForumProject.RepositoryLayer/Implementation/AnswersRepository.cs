using JGB2ForumProject.DataModels;
using JGB2ForumProject.RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGB2ForumProject.RepositoryLayer.Implementation
{
    public class AnswersRepository:IAnswerRepository
    {
        JGB2ForumDBContext db;
        IQuestionRepository qr;
        IVotesRepository vr;

        public AnswersRepository()
        {
            db = new JGB2ForumDBContext();
            qr = new QuestionRepository();
            vr = new VotesRepository();
        }

        public void InsertAnswer(Answer a)
        {
            db.Answers.Add(a);
            db.SaveChanges();
            qr.UpdateQuestionAnswersCount(a.QuestionID, 1);
        }

        public void UpdateAnswer(Answer a)
        {
            Answer ans = db.Answers.Where(temp => temp.AnswerID == a.AnswerID).FirstOrDefault();
            if (ans != null)
            {
                ans.AnswerText = a.AnswerText;
                db.SaveChanges();
            }
        }

        public void UpdateAnswerVotesCount(int aid, int uid, int value)
        {
            Answer ans = db.Answers.Where(temp => temp.AnswerID == aid).FirstOrDefault();
            if (ans != null)
            {
                ans.VotesCount += value;
                db.SaveChanges();
                qr.UpdateQuestionVotesCount(ans.QuestionID, value);
                vr.UpdateVote(aid, uid, value);
            }
        }

        public void DeleteAnswer(int aid)
        {
            Answer ans = db.Answers.Where(temp => temp.AnswerID == aid).First();
            if (ans != null)
            {
                db.Answers.Remove(ans);
                db.SaveChanges();
                qr.UpdateQuestionAnswersCount(ans.QuestionID, -1);
            }
        }
        public List<Answer> GetAnswersByQuestionID(int qid)
        {
            List<Answer> ans = db.Answers.Where(temp => temp.QuestionID == qid).OrderByDescending(temp => temp.AnswerDateAndTime).ToList();
            return ans;
        }
        public List<Answer> GetAnswersByAnswerID(int aid)
        {
            List<Answer> ans = db.Answers.Where(temp => temp.AnswerID == aid).ToList();
            return ans;
        }
    }
}

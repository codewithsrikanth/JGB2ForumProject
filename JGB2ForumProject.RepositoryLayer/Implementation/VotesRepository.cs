using JGB2ForumProject.DataModels;
using JGB2ForumProject.RepositoryLayer.Interfaces;
using System.Linq;

namespace JGB2ForumProject.RepositoryLayer.Implementation
{
    public class VotesRepository:IVotesRepository
    {
        JGB2ForumDBContext _dbContext;
        public VotesRepository()
        {
            _dbContext = new JGB2ForumDBContext();
        }

        public void UpdateVote(int aid, int uid, int value)
        {
            int updateValue;
            if (value > 0) updateValue = 1;
            else if(value < 0) updateValue = -1;
            else updateValue = 0;
            Vote vote = _dbContext.Votes.Where(x => x.AnswerID == aid && x.UserID == uid).FirstOrDefault();
            if(vote != null)
            {
                vote.VoteValue = updateValue;
            }
            else
            {
                Vote newVote = new Vote() {AnswerID = aid,UserID = uid, VoteValue=value };
            }
        }
    }
}

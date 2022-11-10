namespace JGB2ForumProject.RepositoryLayer.Interfaces
{
    interface IVotesRepository
    {
        void UpdateVote(int aid, int uid, int value);
    }
}

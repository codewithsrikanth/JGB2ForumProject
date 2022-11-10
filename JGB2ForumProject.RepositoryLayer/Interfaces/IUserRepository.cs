using JGB2ForumProject.DataModels;
using System.Collections.Generic;

namespace JGB2ForumProject.RepositoryLayer
{
    public interface IUserRepository
    {
        void InsertUser(User u);
        void UpdateUserDetails(User u);
        void UpdateUserPassword(User u);
        void DeleteUser(int uid);
        List<User> GetUsers();
        User GetUserByEmailAndPassword(string email, string password);
        User GetUserByEmail(string email);
        User GetUserByUserID(int uid);
        int GetLatestUserID();
    }
}

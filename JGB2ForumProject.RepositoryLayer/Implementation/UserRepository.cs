using JGB2ForumProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JGB2ForumProject.RepositoryLayer
{
    public class UserRepository: IUserRepository
    {
        JGB2ForumDBContext db;
        public UserRepository()
        {
            db = new JGB2ForumDBContext();
        }

        public void DeleteUser(int uid)
        {
            db.Users.Remove(db.Users.Where(x => x.UserID == uid).FirstOrDefault());
            db.SaveChanges();
        }

        public int GetLatestUserID()
        {
            int uid = db.Users.Select(x => x.UserID).Max();
            return uid;
        }

        public User GetUserByEmail(string email)
        {
            return db.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            User user = db.Users.Where(x => x.Email == email && x.PasswordHash == password).FirstOrDefault();
            return user;
        }

        public User GetUserByUserID(int uid)
        {
            try
            {
                if (uid != 0)
                {
                    User user = db.Users.Where(x => x.UserID == uid).FirstOrDefault();
                    return user;
                }
                else
                {
                    LogErrors.LogError("No User Exists", DateTime.Now);
                    return new User();
                }
            }
            catch (Exception ex)
            {
                LogErrors.LogError(ex.Message, DateTime.Now);
            }
            return new User();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public void InsertUser(User u)
        {
            db.Users.Add(u);
            db.SaveChanges();
        }

        public void UpdateUserDetails(User u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateUserPassword(User u)
        {
            db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}

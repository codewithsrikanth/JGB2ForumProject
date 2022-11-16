using AutoMapper;
using JGB2ForumProject.DataModels;
using JGB2ForumProject.RepositoryLayer;
using JGB2ForumProject.ServiceLayer.Interfaces;
using JGB2ForumProject.ViewModels;
using System.Collections.Generic;

namespace JGB2ForumProject.ServiceLayer.Implementations
{
    public class UserService : IUserService
    {
        IUserRepository ur;
        public UserService()
        {
            ur = new UserRepository();
        }

        public void DeleteUser(int uid)
        {
            throw new System.NotImplementedException();
        }

        public List<UserViewModel> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public UserViewModel GetUserByUserID(int uid)
        {
            throw new System.NotImplementedException();
        }

        public UserViewModel GetUsersByEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public UserViewModel GetUsersByEmailAndPassword(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public int InsertUser(RegisterUserViewModel uvm)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterUserViewModel, User>();
                cfg.IgnoreUnmapped();
            });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<RegisterUserViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.InsertUser(u);
            int uid = ur.GetLatestUserID();
            return uid;
        }

        public void UpdateUserDetails(EditUserDetailsViewModel uvm)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            throw new System.NotImplementedException();
        }
    }
}

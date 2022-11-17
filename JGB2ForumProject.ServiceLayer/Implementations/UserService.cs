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

        public int InsertUser(RegisterUserViewModel uvm)
        {
            //var config = new MapperConfiguration(cfg => { 
            //    cfg.CreateMap<RegisterViewModel, User>(); 
            //    cfg.IgnoreUnmapped(); } );
            //IMapper mapper = config.CreateMapper();
            //User u = mapper.Map<RegisterViewModel, User>(uvm);
            User u = new User();
            u.Email = uvm.Email;
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            u.Name = uvm.Name;
            u.Mobile = uvm.Mobile;
            ur.InsertUser(u);
            int uid = ur.GetLatestUserID();
            return uid;
        }

        public void UpdateUserDetails(EditUserDetailsViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserDetailsViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserDetailsViewModel, User>(uvm);
            ur.UpdateUserDetails(u);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, User>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            User u = mapper.Map<EditUserPasswordViewModel, User>(uvm);
            u.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.Password);
            ur.UpdateUserPassword(u);
        }

        public void DeleteUser(int uid)
        {
            ur.DeleteUser(uid);
        }

        public List<UserViewModel> GetAllUsers()
        {
            List<User> u = ur.GetUsers();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<User>, List<UserViewModel>>(u);
            return uvm;
        }

        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
            User u = ur.GetUserByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password));
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            User u = ur.GetUserByEmail(Email);
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }

        public UserViewModel GetUserByUserID(int UserID)
        {
            User u = ur.GetUserByUserID(UserID);
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<User, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<User, UserViewModel>(u);
            }
            return uvm;
        }
    }
}

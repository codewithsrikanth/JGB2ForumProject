using JGB2ForumProject.ViewModels;
using System.Collections.Generic;

namespace JGB2ForumProject.ServiceLayer.Interfaces
{
    public interface IUserService
    {
        int InsertUser(RegisterUserViewModel uvm);
        void UpdateUserDetails(EditUserDetailsViewModel uvm);
        void UpdateUserPassword(EditUserPasswordViewModel uvm);
        void DeleteUser(int uid);    
        List<UserViewModel> GetAllUsers();
        UserViewModel GetUsersByEmailAndPassword(string email, string password);
        UserViewModel GetUsersByEmail(string email);
        UserViewModel GetUserByUserID(int uid);
    }
}

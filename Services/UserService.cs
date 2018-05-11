using System;
using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services
{
    public class UserService : IUserService
    {
        private UserRepo _userRepo;
        public UserService()
        {
            _userRepo = new UserRepo();
        }
        public List<UserListViewModel> GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();
            return users; 
        }

        public void processUser(RegisterViewModel user)
        {
            if(string.IsNullOrEmpty(user.username)) { throw new Exception("Email is missing"); }
            if(string.IsNullOrEmpty(user.password)) { throw new Exception("Password is missing"); }
            if(string.IsNullOrEmpty(user.name)) { throw new Exception("Name is missing"); }
            if(string.IsNullOrEmpty(user.socialSecurityNumber)) { throw new Exception("SSN is missing"); }
            if(string.IsNullOrEmpty(user.phoneNumber)) { throw new Exception("Phone number is missing"); }
        }
    }
}
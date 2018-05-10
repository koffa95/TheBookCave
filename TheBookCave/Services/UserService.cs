using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services
{
    public class UserService
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
    }
}
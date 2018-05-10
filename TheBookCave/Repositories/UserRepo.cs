using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class UserRepo
    {
        private DataContext _db;
        public UserRepo()
        {
            _db = new DataContext();
        }
        public List<UserListViewModel> GetAllUsers()
        {
            var users = (from u in _db.Users
                         select new UserListViewModel
                         {
                              username = u.username,
                              staff = u.staff
                         }).ToList();

            return users;
        }
    }
}
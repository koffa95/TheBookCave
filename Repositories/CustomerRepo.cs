using System.Collections.Generic;
using System.Linq;
using TheBookCave.Data;
using TheBookCave.Models.ViewModels;

namespace TheBookCave.Repositories
{
    public class CustomerRepo
    {
        private DataContext _db;
        public CustomerRepo()
        {
            _db = new DataContext();
        }
        public RegisterViewModel GetCustomer()
        {
            var customer = (from c in _db.Customer
                            join u in _db.Users on c.userId equals u.id
                            select new RegisterViewModel
                            {
                                username = u.username,
                                staff = u.staff,
                                password = u.password,
                                name = c.name,
                                socialSecurityNumber = c.socialSecurityNumber,
                                phoneNumber = c.phoneNumber
                            }).First();

            return customer;
        }
    }
}
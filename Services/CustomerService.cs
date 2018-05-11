using System.Collections.Generic;
using TheBookCave.Models.ViewModels;
using TheBookCave.Repositories;

namespace TheBookCave.Services
{
    public class CustomerService
    {
        private CustomerRepo _customerRepo;
        public CustomerService()
        {
            _customerRepo = new CustomerRepo();
        }
        public RegisterViewModel GetCustomer()
        {
            var customer = _customerRepo.GetCustomer();
            return customer; 
        }
    }
}
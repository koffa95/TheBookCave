using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage="Email is required")]
        [EmailAddress]
        public string username { get; set; }
        [Required (ErrorMessage="Password is required")]
        public string password { get; set; }
        public bool staff { get; set; }
        [Required]
        public int userId { get; set; }
        [Required (ErrorMessage="Name is required")]
        public string name { get; set; }
        [Required (ErrorMessage="SSN is required")]
        public string socialSecurityNumber { get; set; }
        [Required (ErrorMessage="Phone number is required")]
        public string phoneNumber { get; set; }
    }
}
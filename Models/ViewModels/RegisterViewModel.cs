using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public bool staff { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string socialSecurityNumber { get; set; }
        [Required]
        public string phoneNumber { get; set; }
    }
}
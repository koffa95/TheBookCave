using System.ComponentModel.DataAnnotations;

namespace TheBookCave.Models.ViewModels
{
    public class LogInViewModel
    {
        [EmailAddress]
        public string username { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}
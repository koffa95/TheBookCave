namespace TheBookCave.Models.ViewModels
{
    public class AuthorListViewModel
    {
        public int authorId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public bool alive { get; set; }
        public string countryOfBirth { get; set; }
        public int yearOfBirth { get; set; }
        public string image { get; set; }
        public string shortDescription { get; set; }
    }
}
namespace TheBookCave.Data.EntityModels
{
    public class Customer : User
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string socialSecurityNumber { get; set; }
        public string phoneNumber { get; set; }
    }
}
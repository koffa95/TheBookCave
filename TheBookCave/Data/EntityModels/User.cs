namespace TheBookCave.Data.EntityModels
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool staff { get; set; }
    }
}
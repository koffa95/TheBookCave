namespace TheBookCave.Data.EntityModels
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int authorId { get; set; }
        public string genre { get; set; }
        public int releaseYear { get; set; }
        public string publisher { get; set; }
        public string translator { get; set; }
        public string originalLanguage {get; set;}
        public string language {get; set;}
        public int pages {get; set;}
        public int price {get; set;}
        public string image {get; set;}
        public string shortDescription { get; set; }
    }
}
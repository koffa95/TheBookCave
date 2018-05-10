using System;

namespace TheBookCave.Models.ViewModels
{
    public class AudiobookListViewModel
    {
        public int bookId {get; set;}
        public string title {get; set;}
        public string authorId {get; set;}
        public string translator {get; set;}
        public string narrator {get; set;}
        public string originalLanguage {get; set;}
        public string languages {get; set;}
        public TimeSpan booklength {get; set;}
        public int price {get ; set;} 
    }
}
    
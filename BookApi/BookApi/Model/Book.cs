namespace BookApi.Model
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set;}
        public string description { get; set;}
        public string author { get; set; }
        public DateTime year_of_publication { get; set; }
    }
}

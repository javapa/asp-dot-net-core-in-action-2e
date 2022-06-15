namespace AddRazorPages.Entities
{
    public class Quote
    {
        public Quote(int id, string text, string author)
        {
            Id = id;
            Author = author;
            Text = text;
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Text} - {Author}"; 
        }
    }
}

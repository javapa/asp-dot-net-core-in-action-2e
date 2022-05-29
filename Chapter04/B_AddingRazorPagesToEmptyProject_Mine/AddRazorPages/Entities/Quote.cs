namespace AddRazorPages.Entities
{
    public class Quote
    {
        public Quote(string text, string author)
        {
            Author = author;
            Text = text;
        }

        public string Author { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{Text} - {Author}"; 
        }
    }
}

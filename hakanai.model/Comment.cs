namespace hakanai.domain.models
{
    public class Comment
    {
        public Account User { get; set; }
        public Rating Rating { get; set; }

    }
}
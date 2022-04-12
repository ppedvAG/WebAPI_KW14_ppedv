namespace SharedLib
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; }   
        public string Description { get; set; } 

        public MovieGenre Genre { get; set; }
    }

    public enum MovieGenre { Action, Thriller, Drama, Comedy, Romance, Horror, Doku}
}
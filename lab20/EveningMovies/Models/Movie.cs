namespace EveningMovies.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Genre { get; set; }
		public string RecommendedBy { get; set; }
		public DateTime DateAdded { get; set; }
	}
}

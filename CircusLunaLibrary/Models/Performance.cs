namespace CircusLunaLibrary.Models
{
	public class Performance
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public City City { get; set; }
		public List<Artist> Artists { get; set; }
		public Venue Venue { get; set; }
		public Performance(string name, Venue venue, DateTime date, DateTime time, City city, List<Artist> artists)
		{
			Id = Guid.NewGuid().ToString().Substring(0, 8);
			Name = name;
			Venue = venue;
			Date = date;
			Time = time;
			City = city;
			Artists = artists;
		}

        public override string ToString()
        {
			return $"Forestilling: {Name}\nSted: {Venue}\nDato og tid:{Date} {Time}\nBy: {City}\nArtister: {Artists}";
        }
	}
}

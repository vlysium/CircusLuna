namespace CircusLunaLibrary.Models
{
	public class Performance
	{
        /// <summary>
        /// Name of the performance
        /// </summary>
        public string Name { get; set; }

		/// <summary>
		/// GUID unique identifier for the performance.
		/// </summary>
		public string PerformanceId { get; set; }

		/// <summary>
		/// Date and time of the performance.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// City where the performance takes place.
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// The venue includes the list of seats available for the performance.
		/// </summary>
		public Venue Venue { get; set; }

		/// <summary>
		/// List of artists performing in the performance.
		/// </summary>
		public List<Artist> Artists { get; set; }

		/// <summary>
		/// Constructor to initialize a new performance with the specified date, city, and artists.
		/// </summary>
		/// <param name="date">
		/// The date and time of the performance.
		/// </param>
		/// <param name="city">
		/// The city where the performance takes place.
		/// </param>
		/// <param name="venue">
		/// The venue includes the list of seats available for the performance.
		/// </param>
		/// <param name="artists">
		/// The list of artists performing in the performance.
		/// </param>
		public Performance(string name, DateTime date, City city, Venue venue, List<Artist> artists)
		{
			PerformanceId = Guid.NewGuid().ToString().Substring(0, 8); // Generate a 8-character unique ID
			Name = name;
			Date = date;
			City = city;
			Venue = venue;
			Artists = artists;
		}
	}
}

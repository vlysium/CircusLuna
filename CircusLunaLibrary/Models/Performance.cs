using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
    public class Performance
	{
		/// <summary>
		/// GUID unique identifier for the performance.
		/// </summary>
		public string PerformanceId { get; set; }

        /// <summary>
        /// Name of the performance
        /// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Description of the performance, including details about the acts, theme, or any special features.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Date and time of the performance.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// City where the performance takes place.
		/// </summary>
		public City City { get; set; }

		/// <summary>
		/// The ID of the venue where the performance takes place.
		/// </summary>
		public string VenueId { get; set; }

		/// <summary>
		/// List of artists performing in the performance.
		/// </summary>
		public List<Artist> Artists { get; set; }

		/// <summary>
		/// Default constructor to initialize a new performance with a unique identifier.
		/// </summary>
        public Performance()
		{
            PerformanceId = Guid.NewGuid().ToString().Substring(0, 8);
        }

        /// <summary>
        /// Constructor to initialize a new performance with the specified date, city, and artists.
        /// </summary>
        /// <param name="name">
        /// The name of the performance.
        /// </param>
        /// <param name="description">
        /// A description of the performance, including details about the acts, theme, or any special features.
        /// </param>
        /// <param name="date">
        /// The date and time of the performance.
        /// </param>
        /// <param name="venueId">
        /// The ID of the venue where the performance takes place.
        /// </param>
        /// <param name="city">
        /// The city where the performance takes place.
        /// </param>
        /// <param name="artists">
        /// The list of artists performing in the performance.
        /// </param>
        public Performance(string name, string description, DateTime date, string venueId, City city, List<Artist> artists) : this()
		{			
			Name = name;
			Description = description;
			Date = date;
			City = city;
			VenueId = venueId;
			Artists = artists;
		}
	}
}

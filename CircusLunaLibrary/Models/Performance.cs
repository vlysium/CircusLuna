namespace CircusLunaLibrary.Models
{
	public class Performance
	{
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
		/// List of standard seats for the performance.
		/// </summary>
		public List<Seat> Seats { get; set; }

		/// <summary>
		/// List of VIP seats for the performance.
		/// </summary>
		public List<Seat> VipSeats { get; set; }

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
		/// <param name="seats">
		/// The list of standard seats for the performance.
		/// </param>
		/// <param name="vipSeats">
		/// The list of VIP seats for the performance.
		/// </param>
		/// <param name="artists">
		/// The list of artists performing in the performance.
		/// </param>
		public Performance(DateTime date, City city, List<Seat> seats, List<Seat> vipSeats, List<Artist> artists)
		{
			PerformanceId = Guid.NewGuid().ToString().Substring(0, 8); // Generate a 8-character unique ID
			Date = date;
			City = city;
			Seats = seats;
			VipSeats = vipSeats;
			Artists = artists;
		}
	}
}

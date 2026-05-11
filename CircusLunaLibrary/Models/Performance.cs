namespace CircusLunaLibrary.Models
{
	public class Performance 
	{
        public string PerformanceId { get; set; }
        public DateTime DateTime { get; set; }
		public City City { get; set; }
		
		public List<Seat> Seats { get; set; }

		public List<Artist> Artists { get; set; }




		/* jeg opretter her en tomme liste for artist og seats , en tom liste for disse skal være klar til at man 
		 * putter data i . en tom liste er typsisk ved ();. */

		public Performance(DateTime dateTime, City city, Seat seat, Artist artist)
		{
			PerformanceId = Guid.NewGuid().ToString().Substring(0, 8);
			DateTime = dateTime;
			City = city;
			Seats = new List<Seat>();
			Artists = new List<Artist>();
			
        }

        public override string ToString()
        {
			return $"PerformanceId: {PerformanceId}\n" +
				   $"DateTime : {DateTime}\n" +
				   $"City: {City}\n" +
				   $"Seats : {Seats}\n" +
				   $"Artist: {Artists}\n";
        }
	}
}

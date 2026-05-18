using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
    public class Performance
	{

        public string Name { get; set; }
		public string PerformanceId { get; set; }
		public DateTime Date { get; set; }
		public City ThisCity { get; set; }
        [Required(ErrorMessage = "Forestillingen skal have minimum én artist.")]
        public List<Artist> Artists { get; set; }
        public Performance()
		{
            PerformanceId = Guid.NewGuid().ToString().Substring(0, 8);
        }
        public Performance(DateTime date, string name, City city, List<Artist> artists):this()
		{			
			Name = name;
			Date = date;
			ThisCity = city;			
			Artists = artists;
		}
	}
}

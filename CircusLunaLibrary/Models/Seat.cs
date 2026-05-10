namespace CircusLunaLibrary.Models
{
		public class Seat
		{
			public string SeatID { get; set; }
			public string Section { get; set; }		
			public string Number { get; set; }
			public SeatType SeatType { get; set; }		

			public Seat(string section, string number, SeatType seatType)
			{
				SeatID = Guid.NewGuid().ToString().Substring(0,8);
				Section = section;			
				Number = number;
				SeatType = seatType;				
			}
			public override string ToString()
			{
				return $"Siddeplads:{Section}, {Number}\nType: {SeatType}";
			}
		}
}

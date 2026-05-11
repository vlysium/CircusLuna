namespace CircusLunaLibrary.Models
{
		public class Seat
		{
			public string SeatID { get; set; }
			public char Row { get; set; }		
			public int Number { get; set; }
			public SeatType SeatType { get; set; }		

			public Seat(char row, int number, SeatType seatType)
			{
				SeatID = Guid.NewGuid().ToString().Substring(0,8);
				Row = row;			
				Number = number;
				SeatType = seatType;				
			}
			public override string ToString()
			{
				return $"Siddeplads:{Row}{Number}\nType: {SeatType}";
			}
		}
}

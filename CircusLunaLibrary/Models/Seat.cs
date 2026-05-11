namespace CircusLunaLibrary.Models
{
	public class Seat 
	{
        public string SeatId { get; set; }
        public string SeatName { get; set; }
        public bool IsReserved { get; set; }
		
		SeatType SeatType { get; set; }



		public Seat(string seatName,SeatType seatType)
		{
			SeatId = Guid.NewGuid().ToString().Substring(0, 3);
			SeatName = seatName;
            SeatType = seatType;
		}


        public override string ToString()
        {
			return $"Seat Id:{SeatId}\n" +
				   $"Seat Name : {SeatName}\n" +
				   $"Is reserved? : {IsReserved}\n" +
				   $"Seat Type : {SeatType}\n";

		}
	}
}

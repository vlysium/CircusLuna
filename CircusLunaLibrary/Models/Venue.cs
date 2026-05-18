namespace CircusLunaLibrary.Models
{
	public class Venue
	{
		/// <summary>
		/// The name of the venue.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// List of seats available in the venue. The first row (A) is VIP, and the rest are standard.
		/// </summary>
		public List<Seat> Seats { get; set; }
		public Venue()
		{
            InitializeSeats();
        }

		public Venue(string name):this()
		{
			Name = name;			
		}

		/// <summary>
		/// Reserves a seat in the venue for a customer.
		/// </summary>
		/// <param name="seatId">The ID of the seat to reserve.</param>
		/// <param name="customerId">The ID of the customer reserving the seat.</param>
		/// <exception cref="Exception">Thrown when the seat is already reserved or does not exist.</exception>
		//public void ReserveSeat(string seatId, string customerId)
		//{
		//	foreach (Seat seat in Seats)
		//	{
		//		// Find the seat by its id
		//		if (seat.SeatId == seatId)
		//		{
		//			// Check if the seat is already reserved
		//			if (seat.ReservedBy != null)
		//			{
		//				throw new Exception($"Seat {seatId} is already reserved.");
		//			}

		//			// Reserve the seat for the customer
		//			seat.ReservedBy = customerId;
		//			return;
		//		}
		//	}
		//	throw new Exception($"Seat with ID {seatId} does not exist.");
		//}

		/// <summary>
		/// Initializes the seats for the venue. The first row (A) is VIP, and the rest are standard.
		/// There are 15 rows (A to O) and 10 columns (1 to 10) for a total of 150 seats.
		/// </summary>
		private void InitializeSeats()
		{
			Seats = new List<Seat>();

			for (char i = 'A'; i <= 'O'; i++) // 15 rows (A to O)
			{
				for (int j = 1; j <= 10; j++) // 10 columns (1 to 10)
				{
					Seat newSeat = new Seat(i, j);

					// First row is VIP, the rest are standard
					if (i == 'A')
					{
						newSeat.SeatType = SeatType.VIP;
					}

					Seats.Add(newSeat);
				}
			}
		}
        //public void InitializeSeats()
        //kræver VipSeats og StandardSeats properties. Mulighed for flere telte.
        //{
        //    int seatsPerRow = 10;
        //
        //    for (int i = 0; i < VipSeats; i++)
        //    {
        //        Seats.Add(new Seat('V', i+1, SeatType.VIP));
        //    }

        //    for (int i = 0; i < StandardSeats; i++)
        //    {
    //			char charRow = (char)('A' + (i / seatsPerRow)); 
    //			int seatNumber = (i % seatsPerRow) + 1;  
    //			Seats.Add(new Seat(charRow, seatNumber, SeatType.standard));
        //     }
        //		
        //}

    }//TYPE CASTING: computeren ser chars som tal. Derfor A+1=B. (char) er typecasting. Vi caster tallet til en char efter udregningen.
     //MODULUS: Vi tager det, der er tilbage. 0%10=0+1 -> nr 1. 5%10=5+1 -> nr 6. 27%10=7+1 -> nr 8 osv. 10 er en hel "pakke". hver gang en hel "pakke" udfyldes, ignorerer vi det, og kigger på hvad der er tilbage.
}

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

		public Venue(string name)
		{
			Name = name;
			InitializeSeats();
		}

		/// <summary>
		/// Reserves a seat in the venue for a customer.
		/// </summary>
		/// <param name="seatId">The ID of the seat to reserve.</param>
		/// <param name="customerId">The ID of the customer reserving the seat.</param>
		/// <exception cref="Exception">Thrown when the seat is already reserved or does not exist.</exception>
		public void ReserveSeat(string seatId, string customerId)
		{
			foreach (Seat seat in Seats)
			{
				// Find the seat by its id
				if (seat.SeatId == seatId)
				{
					// Check if the seat is already reserved
					if (seat.ReservedBy != null)
					{
						throw new Exception($"Seat {seatId} is already reserved.");
					}

					// Reserve the seat for the customer
					seat.ReservedBy = customerId;
					return;
				}
			}
			throw new Exception($"Seat with ID {seatId} does not exist.");
		}

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
	}
}

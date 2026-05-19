using System.Text.Json.Serialization;

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
		[JsonIgnore]
		public List<Seat> AllSeats { get; set; }

		// /// <summary>
		// /// Dictionary to keep track of reserved seats, where the key is the seat ID and the value is the customer ID who reserved it.
		// /// </summary>
		// public Dictionary<string, string> ReservedSeats { get; set; }

		[JsonConstructor]
		public Venue() { }

		/// <summary>
		/// Default constructor to initialize the venue with a name and an empty list of seats. It also initializes the reserved seats dictionary.
		/// </summary>
		/// <param name="name">The name of the venue.</param>
		/// <param name="seats">The list of seats available in the venue.</param>
		public Venue(string name, List<Seat> seats): this()
		{
			Name = name;
			AllSeats = seats;
		}

		// /// <summary>
		// /// Reserves a seat in the venue for a customer.
		// /// </summary>
		// /// <param name="seatId">The ID of the seat to reserve.</param>
		// /// <param name="customerId">The ID of the customer reserving the seat.</param>
		// /// <exception cref="Exception">Thrown when the seat is already reserved or does not exist.</exception>
		// public void ReserveSeat(string seatId, string customerId)
		// {
		// 	foreach (Seat seat in AllSeats)
		// 	{
		// 		// Find the seat by its id
		// 		if (seat.SeatId == seatId)
		// 		{
		// 			// Check if the seat is already reserved
		// 			if (ReservedSeats.ContainsKey(seatId))
		// 			{
		// 				throw new Exception($"Seat with ID {seatId} is already reserved.");
		// 			}

		// 			// Reserve the seat for the customer
		// 			ReservedSeats.Add(seatId, customerId);
		// 			return;
		// 		}
		// 	}
		// 	throw new Exception($"Seat with ID {seatId} does not exist.");
		// }

        //public void InitializeSeats()
		//kræver VipSeats og StandardSeats properties. Mulighed for flere telte.
        //{
        //    int seatsPerRow = 10;
        //    for (int i = 0; i < VipSeats; i++)
        //    {
        //        AllSeats.Add(new Seat('0', i, SeatType.VIP));
        //    }

        //    for (int i = 0; i < StandardSeats; i++)
        //    {
        //        char charRow = (char)('A' + (i / seatsPerRow)); //TYPE CASTING: computeren ser chars som tal. Derfor A+1=B. (char) er typecasting. Vi caster tallet til en char efter udregningen.
        //        int seatNumber = (i % seatsPerRow) + 1;  //MODULUS: Vi tager det, der er tilbage. 0/10=0+1 -> nr 1. 5/10=5+1 -> nr 6. 27/10=7+1 -> nr 8 osv. Ignorer 10'erne som udg�r ROWS.
        //        if (charRow == 'A' && (i >= 0 && i <= 9))
        //            AllSeats.Add(new Seat(charRow, seatNumber, SeatType.standard));

        //    }
        //}

    }
}

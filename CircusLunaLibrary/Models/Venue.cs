namespace CircusLunaLibrary.Models
{
	public class Venue
	{
		public string ID { get; set; }
		public int VipSeats { get; set; }
		public int StandardSeats { get; set; }		
		public string Name { get; set; }
		public List<Seat> Seats { get; set; }
        public Venue()
		{
		}
        public Venue(string name, int vipSeats, int standardSeats) : this()
        {
            ID = Guid.NewGuid().ToString().Substring(0, 8);
            Name = name;
            VipSeats = vipSeats;
            StandardSeats = standardSeats;
            
            InitializeSeats();
        }
        public void InitializeSeats()
        {
            int seatsPerRow = 20;                           //Vi bestemmer hvor mange sæder per række
            Seats = new List<Seat>();

            for (int i = 0; i < VipSeats; i++)              //VIP sæder oprettes
            {
                Seats.Add(new Seat('V', i + 1, SeatType.VIP));
            }

            for (int i = 0; i < StandardSeats; i++)         //Standard sæder oprettes
            {
                char charRow = (char)('A' + (i / seatsPerRow));
                int seatNumber = (i % seatsPerRow) + 1;
                Seats.Add(new Seat(charRow, seatNumber, SeatType.Standard));
            }

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
        //private void InitializeSeats()
        //{
        //	Seats = new List<Seat>();

        //	for (char i = 'A'; i <= 'O'; i++) // 15 rows (A to O)
        //	{
        //		for (int j = 1; j <= 10; j++) // 10 columns (1 to 10)
        //		{
        //			Seat newSeat = new Seat(i, j);

        //			// First row is VIP, the rest are standard
        //			if (i == 'A')
        //			{
        //				newSeat.SeatType = SeatType.VIP;
        //			}

        //			Seats.Add(newSeat);
        //		}
        //	}
        //}


    }//TYPE CASTING: computeren ser chars som tal. Derfor A+1=B. (char) er typecasting. Vi caster tallet til en char efter udregningen.
     //MODULUS: TAL % TAL2. Hvor mange gange går TAL2 op i TAL1? Hvis det er 0 gange, vil det overskydende tal ALTID svare til TAL1. 20/20 så er overskuddet 0. 40/20 giver også 0. osv. 1, 21, 41 giver alt sammen 1 i overskud.
}

using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents a physical performance venue or arena layout.
    /// Manages the allocation, structural row/column distribution, and programmatic matrix generation 
    /// of both standard and premium structural seating zones.
    /// </summary>
	public class Venue
	{
        /// <summary>
        /// Gets or sets the unique alphanumeric identifier for the venue.
        /// </summary>
		public string ID { get; set; }
        /// <summary>
        /// Gets or sets the total capacity count allocated specifically for VIP luxury seats.
        /// </summary>
		public int VipSeats { get; set; }
        /// <summary>
        /// Gets or sets the total capacity count allocated specifically for standard seats.
        /// </summary>
		public int StandardSeats { get; set; }
        /// <summary>
        /// Gets or sets the descriptive title or name of the physical venue.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the global registry collection tracking all individual concrete physical seat models mapped inside the venue.
        /// Defaults to an empty initialized collection.
        /// </summary>
        public List<Seat> Seats { get; set; } = new List<Seat>();
        /// <summary>
        /// Initializes a new instance of the <see cref="Venue"/> class with default empty values.
        /// </summary>
        public Venue()
		{            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Venue"/> class with explicit identification and seat block parameters.
        /// Triggers an immediate programmatic matrix assembly routine to generate the physical seats list.
        /// </summary>
        /// <param name="name">The descriptive title or name of the venue.</param>
        /// <param name="vipSeats">The quantity of premium VIP seats to distribute into row structures.</param>
        /// <param name="standardSeats">The quantity of typical standard seats to distribute into row structures.</param>
        public Venue(string name, int vipSeats, int standardSeats) : this()
        {
            ID = Guid.NewGuid().ToString().Substring(0, 8);
            Name = name;
            VipSeats = vipSeats;
            StandardSeats = standardSeats;
            InitializeSeats();

        }
        /// <summary>
        /// Programmatically builds the geometric seating matrix configuration layout.
        /// Distributes VIP structural elements into an initial independent block, then maps standard seating zones 
        /// into regular bounded horizontal columns across sequential alphabetical rows.
        /// </summary>
        public void InitializeSeats()
        {
            int seatsPerRow = 20;                           //Vi bestemmer hvor mange s�der per r�kke
            Seats = new List<Seat>();

            for (int i = 0; i < VipSeats; i++)              //VIP s�der oprettes
            {
                Seats.Add(new Seat('V', i + 1, SeatType.VIP));
            }

            for (int i = 0; i < StandardSeats; i++)         //Standard s�der oprettes
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
     //MODULUS: TAL % TAL2. Hvor mange gange g�r TAL2 op i TAL1? Hvis det er 0 gange, vil det overskydende tal ALTID svare til TAL1. 20/20 s� er overskuddet 0. 40/20 giver ogs� 0. osv. 1, 21, 41 giver alt sammen 1 i overskud.
}

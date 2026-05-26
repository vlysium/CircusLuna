using System;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents an individual entry ticket for a circus seat allocation.
    /// Manages core operational values including distinct tier pricing calculation rules based on physical seat seating properties and demographic variations.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// The base market financial charge value assigned for standard seating zones.
        /// </summary>
        public static readonly double StandardPrice = 150;

        /// <summary>
        /// The elevated base structural charge value applied for designated VIP seating zones.
        /// </summary>
        public static readonly double VIPprice = 200;

        /// <summary>
        /// Gets or sets the unique alphanumeric identifier for the individual ticket instance.
        /// Generated automatically as a shortened unique tracking token upon initialization.
        /// </summary>
        public string TicketID { get; set; }

        /// <summary>
        /// Gets or sets the demographic classification tier for this ticket (e.g., Standard, VIP, Barn/Child).
        /// </summary>
        public TicketType Type { get; set; }

        /// <summary>
        /// Gets or sets the physical venue seating coordinate reference bound to this specific ticket.
        /// </summary>
        public Seat Seat { get; set; }

        /// <summary>
        /// Gets or sets the finalized financial cost computed for this entry slip.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ticket"/> class with an explicit demographic type selection and a target physical seat allocation.
        /// Automatically derives an 8-character string token identity using a truncated <see cref="Guid"/> and triggers immediate price evaluations.
        /// </summary>
        /// <param name="type">The demographic category or privilege flag level for the individual ticket buyer.</param>
        /// <param name="seat">The concrete physical coordinate position row allocation tracking details.</param>
        public Ticket(TicketType type, Seat seat)
        {
            TicketID = Guid.NewGuid().ToString().Substring(0, 8);
            Type = type;
            Seat = seat;
            Price = CalculatePrice();
        }

        /// <summary>
        /// Runs internal business pricing matrices to deduce accurate row line costs based on 
        /// interactive combinations of base structural seat types and customer demographic types.
        /// </summary>
        /// <returns>The calculated final decimal ticket price value following applicable surcharge or discount application paths.</returns>
        public double CalculatePrice()
        {
            double price = 0;
            if (Seat.SeatType == SeatType.Standard)
            {
                price += StandardPrice;
            }
            if (Seat.SeatType == SeatType.VIP)
            {
                price += VIPprice;
            }
            if (Type == TicketType.VIP)
            {
                price += 50;
            }
            if (Type == TicketType.Barn && Seat.SeatType == SeatType.Standard)
            {
                price = price * 0.7;
            }
            return price;
        }

        /// <summary>
        /// Returns a formatted string representation tracking vital operational ticket data including identity values, ticket types, and row seat combinations.
        /// </summary>
        /// <returns>A string data overview token detailing basic placement criteria.</returns>
        public override string ToString()
        {
            return $"BilletID: {TicketID} | Billettype: {Type} | Siddeplads: {Seat.SeatRow}{Seat.SeatColumn}";
        }
    }
}
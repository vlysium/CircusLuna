using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
	public class Seat
	{
		/// <summary>
		/// Unique identifier for the seat.
		/// </summary>
		public string SeatId { get; set; }

		/// <summary>
		/// The seat row (e.g., "A", "B", etc.).
		/// </summary>
		public char SeatRow { get; set; }

		/// <summary>
		/// The seat column (e.g., "1", "2", etc.).
		/// </summary>
		public int SeatColumn { get; set; }

		/// <summary>
		/// The type of the seat (Standard or VIP).
		/// </summary>
		public SeatType SeatType { get; set; }

		/// <summary>
		/// The id of the customer who reserved the seat, if any. Null if the seat is not reserved.
		/// </summary>
		//public string? ReservedBy { get; set; }

		/// <summary>
		/// Initializes a new instance of the Seat class with the specified row and column.
		/// </summary>
		/// <param name="seatRow">The row of the seat.</param>
		/// <param name="seatColumn">The column of the seat.</param>
		[JsonConstructor]
		public Seat()
		{
		}
		public Seat(char seatRow, int seatColumn)
		{
			SeatId = $"{seatRow}{seatColumn}"; // Unique identifier based on row and column
			SeatRow = seatRow;
			SeatColumn = seatColumn;
			SeatType = SeatType.Standard;
			//ReservedBy = null;
		}

		/// <summary>
		/// Constructor scaffolding for the Seat class that also takes a seat type.
		/// </summary>
		/// <param name="seatRow">The row of the seat.</param>
		/// <param name="seatColumn">The column of the seat.</param>
		/// <param name="seatType">The type of the seat.</param>
		public Seat(char seatRow, int seatColumn, SeatType seatType): this(seatRow, seatColumn)
		{
			SeatType = seatType;
		}

		public override string ToString()
		{
			return $"Seat {SeatRow}{SeatColumn}";
		}
	}
}

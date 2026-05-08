namespace CircusLunaLibrary.Models
{
	public class Seat
	{
		/// <summary>
		/// The seat number (e.g., "A1", "B2", etc.).
		/// </summary>
		public string SeatNumber { get; set; }

		/// <summary>
		/// The type of the seat (Standard or VIP).
		/// </summary>
		public SeatType SeatType { get; set; }

		/// <summary>
		/// The reservation ID associated with this seat, if it is reserved.
		/// </summary>
		public string ReservationId { get; set; }
	}
}

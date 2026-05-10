using System.Text;

namespace CircusLunaLibrary.Models
{
	public class Reservation
	{
		public string ReservationID { get; set; }
		public Customer Customer { get; set; }
		public Performance Performance { get; set; }
		public List<Ticket> Tickets { get; set; }

		public Reservation()
		{
			ReservationID = Guid.NewGuid().ToString().Substring(0, 8);
		}
		public Reservation(Customer customer, Performance performance, List<Ticket> tickets):this()
		{
			Customer = customer;
			Performance = performance;
			Tickets = tickets;
		}
        public override string ToString()
        {
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Tickets.Count; i++)
			{
				sb.Append(Tickets[i]);
				if (i < Tickets.Count - 1) sb.Append(", ");
			}
			return $"ReservationsID: {ReservationID}\nForestilling: {Performance}\nBiletter: {sb.ToString()}";
        }
	}
}

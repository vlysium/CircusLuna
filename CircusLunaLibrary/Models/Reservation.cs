using System.Reflection.Metadata.Ecma335;

namespace CircusLunaLibrary.Models
{
	public class Reservation 
	{
		public string ReservationId { get; set; }

		public List<Ticket> Tickets { get; set; }

		public string CustomerId { get; set; }


		public Reservation( )
		{
			ReservationId = Guid.NewGuid().ToString().Substring(0, 8);
			Tickets = new List<Ticket>();
			CustomerId = Guid.NewGuid().ToString().Substring(0, 8);
            

		}

		public void AddTicket(Ticket ticket)
		{
			Tickets.Add(ticket);
		}

		public override string ToString()
        {
            string result = "";

            foreach (Ticket ticket in Tickets)
			{
				result = result + ticket;
			}

			return $"{result}\n" +
			       $"Reservation Id : {ReservationId}\n"+
				   $"Customer Id : {CustomerId}\n";
        }
    }
}

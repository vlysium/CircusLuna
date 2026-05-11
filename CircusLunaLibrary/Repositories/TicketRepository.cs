using CircusLunaLibrary.Models;
using System.ComponentModel;

namespace CircusLunaLibrary.Repositories
{
	public class TicketRepository
	{
		private List<Ticket> Ticket;


		public TicketRepository()
		{
			Ticket = new List<Ticket>();
		}

		public void AddTicket(Ticket ticket)
		{
			Ticket.Add(ticket);
		}

		public List<Ticket> GetAllTickets()
		{
			return Ticket;
		}

		public Ticket GetTicketById(string id)
		{
			foreach (Ticket ticket in Ticket)
			{
				if (ticket.TicketId == id)
				{
					return ticket;
				}
			}
			return null;
		}

	}
}

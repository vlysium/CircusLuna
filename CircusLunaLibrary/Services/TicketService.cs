using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;

namespace CircusLunaLibrary.Services
{
	public class TicketService
	{

		private TicketRepository ticketRespsitory;





		/* her opretter jeg min construcor til min service klass som indholder en tom liste . */
		public TicketService()
		{
			ticketRespsitory = new TicketRepository();
		}




		/*her tilføjer jeg en methode som tilføjer ticket til min ticket klasse */
		public void AddTicket(Ticket ticket)
		{
			ticketRespsitory.AddTicket(ticket);
		}





		/*her opretter jeg en methode som henter alle billetter som er i min ticket klass . 
		min methode er en liste af ticket, 
		når methoden bliver kaldt vil den returner ved brug af min ticket Repository */
		public List<Ticket> GetAllTicket()
		{
			return ticketRespsitory.GetAllTickets();
		}




		/* heer opretter jeg en methode som henter alle */

		public Ticket GetTicketById(string ticketId)
		{
			return ticketRespsitory.GetTicketById(ticketId);
		}




		public void ShowTicket()
		{
			foreach (Ticket tickets in ticketRespsitory.GetAllTickets())
			{
                Console.WriteLine(tickets);
			}


		}
	}
}

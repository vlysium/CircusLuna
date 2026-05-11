using System.Transactions;

namespace CircusLunaLibrary.Models
{
	public class Ticket 
	{
		public string TicketId { get; set; }
		public TicketType TicketType { get; set; }

		public Ticket(TicketType ticketType):base()
		{

			TicketId = Guid.NewGuid().ToString().Substring(0, 8);
			TicketType = ticketType;
		}





        /*her opretter jeg en switch som gøre ved at hente paramenter CalculatePrice vil den automatisk 
         * hente prisen også . */
        public double CalculatePrice()
		{
			switch (TicketType)
			{
				case TicketType.Standart:
					return 120;

				case TicketType.Child:
					return 100;

				case TicketType.VIP:
					return 200;

				default:
					return 0;
			}
			
		}



		public override string ToString()
        {

			return $"Ticket id : {TicketId}\n" +
				   $"Ticket type : {TicketType}\n"+
			       $"Ticket price: {CalculatePrice():C2}\n";
        }
	}
}

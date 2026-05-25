using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace CircusLunaLibrary.Services
{
	public class ReservationService
	{	
		private readonly IReservationRepository _reservationRepository;
		private readonly VenueService _venueService;
		private List<Reservation> _reservations = new List<Reservation>();


		public ReservationService(IReservationRepository repository, VenueService venueService)
		{
			_reservationRepository = repository;		
			_reservations = repository.GetAll();
			_venueService = venueService;
		}


		public List<string> GetBusySeatIds(string performanceID)
		{
			List<string> busySeatIds = new List<string>();
			for (int i = 0; i < _reservations.Count; i++)
			{
				if (_reservations[i].Performance.PerformanceId == performanceID)
				{
					foreach (Ticket t in _reservations[i].Tickets)
					{
						busySeatIds.Add(t.Seat.SeatId);
					}
				}
			}
			return busySeatIds;
		}
		

		public void AddReservation(Reservation reservation)
		{			
			_reservationRepository.AddReservation(reservation);
		}

		public void DeleteReservation(string id) 
		{
			_reservationRepository.DeleteReservation(id);
		}

		public void UpdateReservation(string id, Reservation reservation)
		{
			_reservationRepository.UpdateReservation(id, reservation);
		}
		public List<Ticket> CreateTickets(string VenueId, List<string> SeatIds, string TicketTypeString)
		{
            TicketType TicketTypeEnum = StringToTicketType(TicketTypeString);
            Venue venue = _venueService.GetById(VenueId);
            List<Ticket> tickets = new List<Ticket>();
            foreach (string seatId in SeatIds)
            {
                foreach (Seat s in venue.Seats)
                {
                    if (s.SeatId == seatId)
                    {
                        Ticket t = new Ticket(TicketTypeEnum, s);
                        tickets.Add(t);
                        break;
                    }
                }
            }
			return tickets;
        }
		public TicketType StringToTicketType(string TicketTypeString)
		{
            if (!Enum.TryParse(TicketTypeString, out TicketType TicketTypeEnum))
            {
                TicketTypeEnum = TicketType.Standard; // Default fallback
            }
			return TicketTypeEnum;
        }
		  

	}
}

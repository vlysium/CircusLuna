using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System.Data;

namespace CircusLunaLibrary.Services
{
	public class ReservationService
	{	
		private readonly IReservationRepository _reservationRepository;
		private List<Reservation> _reservations = new List<Reservation>();


		public ReservationService(IReservationRepository repository)
		{
			_reservationRepository = repository;		
			_reservations = repository.GetAll();
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

	}
}

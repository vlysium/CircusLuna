using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System.Data;

namespace CircusLunaLibrary.Services
{
	public class ReservationService
	{	
		private readonly IReservationRepository _repo;
		private List<Reservation> _allReservations = new List<Reservation>();


		public ReservationService(IReservationRepository repo)
		{
			_repo = repo;		
			_allReservations = repo.GetAll();
		}


		public List<string> GetBusySeatIds(string performanceID)
		{
			List<string> busySeatIds = new List<string>();
			for (int i = 0; i < _allReservations.Count; i++)
			{
				if (_allReservations[i].Performance.PerformanceId == performanceID)
				{
					foreach (Ticket t in _allReservations[i].Tickets)
					{
						busySeatIds.Add(t.Seat.SeatId);
					}
				}
			}
			return busySeatIds;
		}
		

		public void AddReservation(Reservation reservation)
		{			
			_repo.AddReservation(reservation);
		}

		public void DeleteReservation(string id) 
		{
			_repo.DeleteReservation(id);
		}

		public void UpdateReservation(string id, Reservation reservation)
		{
			_repo.UpdateReservation(id, reservation);
		}

	}
}

using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;

namespace CircusLunaLibrary.Services
{

	public class PerformanceService
	{
		private readonly IPerformanceRepository _performanceRepository;

		/// <summary>
		/// Dependency injection with the repository.
		/// </summary>
		/// <param name="performanceRepository">The performance repository to use.</param>
		public PerformanceService(IPerformanceRepository performanceRepository)
		{
			_performanceRepository = performanceRepository;
		}

		/// <summary>
		/// Reserves a seat for a specific performance.
		/// It retrieves the performance, reserves the seat in the venue, and updates the performance in the repository.
		/// </summary>
		/// <param name="performanceId">The ID of the performance for which to reserve a seat.</param>
		/// <param name="seatId">The ID of the seat to reserve.</param>
		/// <param name="customerId">The ID of the customer reserving the seat.</param>
		/// <exception cref="Exception">Thrown when the performance is not foundor when there is an error reserving the seat.</exception>
		//public void ReserveSeat(string performanceId, string seatId, string customerId)
		//{

		//	// Check if the performance exists
		//	Performance performance = _performanceRepository.GetById(performanceId);
		//	if (performance == null)
		//	{
		//		throw new Exception($"Performance with ID {performanceId} was not found.");
		//	}

		//	// Find the seat in the venue
		//	Seat? seatToReserve = null;
		//	foreach (Seat seat in performance.Venue.Seats)
		//	{
		//		if (seat.SeatId == seatId)
		//		{
		//			seatToReserve = seat;
		//			break;
		//		}
		//	}

		//	// If the seat was not found, throw an exception
		//	if (seatToReserve == null)
		//	{
		//		throw new Exception($"Seat with ID {seatId} was not found.");
		//	}

		//	// Check if the seat is already reserved by another customer
		//	if (seatToReserve.ReservedBy != null)
		//	{
		//		throw new Exception($"Seat {seatId} is already reserved.");
		//	}

		//	// Reserve the seat for the customer
		//	seatToReserve.ReservedBy = customerId;

		//	// Update the performance in the repository to reflect the reserved seat
		//	_performanceRepository.Update(performance);
		//}

		/// <summary>
		/// Gets all performances from the repository.
		/// </summary>
		/// <returns>A list of all performances.</returns>
		public List<Performance> GetAllPerformances()
		{
			return _performanceRepository.GetAll();
		}

		/// <summary>
		/// Gets a performance by its ID from the repository.
		/// </summary>
		/// <param name="performanceId">The ID of the performance to get.</param>
		/// <returns>The performance with the specified ID.</returns>
		public Performance GetPerformance(string performanceId)
		{
			return _performanceRepository.GetById(performanceId);
		}

		/// <summary>
		/// Adds a new performance to the repository.
		/// </summary>
		/// <param name="performance">The performance to add.</param>
		public void AddPerformance(Performance performance)
		{
			_performanceRepository.Add(performance);
		}

		/// <summary>
		/// Updates an existing performance in the repository.
		/// </summary>
		/// <param name="performance">The performance to update.</param>
		public void UpdatePerformance(Performance performance)
		{
			_performanceRepository.Update(performance);
		}

		/// <summary>
		/// Deletes a performance from the repository by its ID.
		/// </summary>
		/// <param name="performanceId">The ID of the performance to delete.</param>
		public void DeletePerformance(string performanceId)
		{
			_performanceRepository.Delete(performanceId);
		}
	}
}

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

		// /// <summary>
		// /// Reserves a seat for a specific performance.
		// /// It retrieves the performance, reserves the seat in the venue, and updates the performance in the repository.
		// /// </summary>
		// /// <param name="performanceId">The ID of the performance for which to reserve a seat.</param>
		// /// <param name="seatId">The ID of the seat to reserve.</param>
		// /// <param name="customerId">The ID of the customer reserving the seat.</param>
		// /// <exception cref="Exception">Thrown when the performance is not foundor when there is an error reserving the seat.</exception>
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
		/// Searches for performances in the repository that match the given search term in their city, venue or name.
		/// </summary>
		/// <param name="searchTerm">The term to search for.</param>
		/// <returns>A list of performances that match the search term.</returns>
		public List<Performance> SearchPerformances(string searchTerm)
		{
			return _performanceRepository.Search(searchTerm);
		}

		/// <summary>
		/// Sorts the performances in the repository based on the specified sort option, using the bubble sort algorithm.
		/// </summary>
		/// <param name="ascending">If true and default behavior, sorts in ascending order (A to Z); if false, sorts in descending order (Z to A).</param>
		/// <returns>The sorted list of performances in the desired order.</returns>
		public List<Performance> SortPerformancesByCity(List<Performance> performances, bool ascending = true)
		{			
			// Get length of the list of performances
			int n = performances.Count;

			// Boolean variable to track if the list is sorted
			bool swapped;

			do
			{
				swapped = false;

				// Iterate through the list of performances
				for (int i = 0; i < n - 1; i++)
				{
					// Compare the current performance's city name with the next immediate performance's city name
					if (string.Compare(performances[i].City.Name, performances[i + 1].City.Name) > 0)
					{
						// Swap the performances if they are in the wrong order,
						// using tuple deconstruction to swap in place without a temporary variable
						(performances[i], performances[i + 1]) = (performances[i + 1], performances[i]);

						// Set swapped to true to indicate that a swap has occurred
						swapped = true;
					}
				}

				// Reduce n by 1 since the last element has "bubbled" up to its correct position and does not need to be checked again
				n--;

			} while (swapped); // Continue looping until no swaps are made, indicating that the list is sorted

			// Extra feature: reverse the list if descending order (Z to A) is desired
			if (!ascending)
			{
				performances.Reverse();
			}

			// Finally return the sorted list of performances
			return performances;
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

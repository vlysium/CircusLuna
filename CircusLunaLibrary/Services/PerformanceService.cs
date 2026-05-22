using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;

namespace CircusLunaLibrary.Services
{

	public class PerformanceService
	{
		private readonly IPerformanceRepository _performanceRepository;

		/// <summary>
		/// Initializes a new instance of the PerformanceService class with the specified performance repository.
		/// </summary>
		/// <param name="performanceRepository">The performance repository to use.</param>
		public PerformanceService(IPerformanceRepository performanceRepository)
		{
			_performanceRepository = performanceRepository;
		}

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
		/// <param name="ascending">If true and default behavior, sorts in ascending order; if false, sorts in descending order.</param>
		/// <returns>The sorted list of performances in the desired order.</returns>
		public List<Performance> SortPerformances(List<Performance> performances, PerformanceSortOption sortOption, bool ascending = true)
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
					// Compare the current performance with the next one based on the specified sort option,
					// using the ComparePerformances helper method to determine their relative order
					int comparisonResult = ComparePerformances(performances[i], performances[i + 1], sortOption);

					// If the comparison result is greater than 0, it means that the current performance should come after the next one
					if (comparisonResult > 0)
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

		/// <summary>
		/// Compares two performances based on the specified sort option and returns an integer indicating their relative order.
		/// </summary>
		/// <param name="p1">First performance</param>
		/// <param name="p2">Second performance</param>
		/// <param name="sortOption">The sort option to use for comparison.</param>
		/// <returns>
		/// A signed integer indicating the relative order of the performances,
		/// where -1 indicates that p1 should come before p2, 0 indicates they are equal,
		/// and 1 indicates that p1 should come after p2.
		/// </returns>
		private int ComparePerformances(Performance p1, Performance p2, PerformanceSortOption sortOption)
		{
			switch (sortOption)
			{
				case PerformanceSortOption.CityName:
					return string.Compare(p1.City.Name, p2.City.Name);

				case PerformanceSortOption.PerformanceName:
					return string.Compare(p1.Name, p2.Name);

				case PerformanceSortOption.PerformanceDate:
					return DateTime.Compare(p1.Date, p2.Date);

				// This default case should never be hit if all enum values are handled,
				// but it's good practice to include it to avoid compiler warnings and to handle unexpected cases.
				default:
					return 0;
			}
		}
	}
}

using System.Globalization;
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
		/// Filters the given list of performances based on the specified region and artist criterias,
		/// using the repository's Filter method to perform the actual filtering logic.
		/// </summary>
		/// <param name="performances">The list of performances to filter.</param>
		/// <param name="region">The region to filter by.</param>
		/// <param name="artist">The artist to filter by.</param>
		/// <returns>A list of performances that match the specified criterias.</returns>
		public List<Performance> FilterPerformances(List<Performance> performances, Region? region, Artist? artist)
		{
			List<Performance> results = new List<Performance>();

			foreach (Performance performance in performances)
			{
				// Skip if region doesn't match
				if (region.HasValue && performance.City.Region != region.Value)
				{
					continue;
				}

				// If an artist filter is specified, check if the performance includes that artist
				if (artist != null)
				{
					bool artistFound = false;

					// Iterate through the list of artists in the performance and check if any of them match the specified artist
					foreach (Artist performanceArtist in performance.Artists)
					{
						if (performanceArtist.ID == artist.ID)
						{
							// If a match is found, set artistFound to true and break out of the loop
							artistFound = true;
							break;
						}
					}

					// If no matching artist was found in the performance, skip it
					if (!artistFound)
					{
						continue;
					}
				}

				// If we reach this point, the performance matches the criterias and can be added to the results
				results.Add(performance);
			}

			return results;
		}

		/// <summary>
		/// Searches for performances in the repository that match the given search term in their city, venue or name.
		/// </summary>
		/// <param name="performances">The list of performances to search within.</param>
		/// <param name="searchTerm">The term to search for.</param>
		/// <returns>A list of performances that match the search term.</returns>
		public List<Performance> SearchPerformances(List<Performance> performances, string searchTerm)
		{
			List<Performance> results = new List<Performance>();

			foreach (Performance performance in performances)
			{
				// Variables for readability
				string lowerSearchTerm = searchTerm.ToLower();
				string lowerCityName = performance.City.Name.ToLower();
				//string lowerVenueName = performance.Venue.Name.ToLower();
				string lowerPerformanceName = performance.Name.ToLower();

				// Check if the search term matches the city, venue or name of the performance, case-insensitive
				// City name
				if (lowerCityName.Contains(lowerSearchTerm))
				{
					results.Add(performance);
					break;
				}
				// Venue name
				//if (lowerVenueName.Contains(lowerSearchTerm))
				//{
				//	results.Add(performance);
				//	break;
				//}
				// Performance name
				if (lowerPerformanceName.Contains(lowerSearchTerm))
				{
					results.Add(performance);
					break;
				}
			}
			return results;
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
					return string.Compare(p1.City.Name, p2.City.Name, new CultureInfo("da-DK"), CompareOptions.IgnoreCase);

				case PerformanceSortOption.PerformanceName:
					return string.Compare(p1.Name, p2.Name, new CultureInfo("da-DK"), CompareOptions.IgnoreCase);

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

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

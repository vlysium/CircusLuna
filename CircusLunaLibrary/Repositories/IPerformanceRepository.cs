using CircusLunaLibrary.Models;

namespace CircusLunaLibrary.Repositories
{
	public interface IPerformanceRepository
	{
		/// <summary>
		/// Gets all performances.
		/// </summary>
		/// <returns>A list of all performances.</returns>
		public List<Performance> GetAll();
		/// <summary>
		/// Gets a performance by its ID.
		/// </summary>
		/// <param name="performanceId">The ID of the performance to retrieve.</param>
		/// <returns>The performance with the specified ID, or null if not found.</returns>
		public Performance GetById(string performanceId);
		/// <summary>
		/// Adds a new performance.
		/// </summary>
		/// <param name="performance">The performance to add.</param>
		public void Add(Performance performance);
		/// <summary>
		/// Updates an existing performance.
		/// </summary>
		/// <param name="performance">The performance to update.</param>
		public void Update(Performance performance);
		/// <summary>
		/// Deletes a performance by its ID.
		/// </summary>
		/// <param name="performanceId">The ID of the performance to delete.</param>
		public void Delete(string performanceId);
	}
}

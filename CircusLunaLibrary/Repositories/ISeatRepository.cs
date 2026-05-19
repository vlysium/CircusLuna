using CircusLunaLibrary.Models;

namespace CircusLunaLibrary.Repositories
{
	public interface ISeatRepository
	{
		/// <summary>
		/// Gets all seats available in the repository.
		/// </summary>
		/// <returns>A list of all seats.</returns>
		public List<Seat> GetAll();
		
		/// <summary>
		/// Gets a seat by its ID.
		/// </summary>
		/// <param name="seatId">The ID of the seat to retrieve.</param>
		/// <returns>The seat with the specified ID.</returns>
		public Seat GetById(string seatId);
	}
}

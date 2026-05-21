using System.Text.Json;
using CircusLunaLibrary.Models;

namespace CircusLunaLibrary.Repositories
{
	public class PerformanceRepository : IPerformanceRepository
	{
		private readonly string _path = Path.Combine("Data", "performances.json");
		private List<Performance> performances = new List<Performance>();

		/// <summary>
		/// Constructor for the PerformanceRepository class. It checks if the JSON file containing the performances exists.
		/// If it does, it loads the performances from the file using the LoadFromFile method.
		/// If the file does not exist, it creates a new file with an empty array and initializes the performances list as an empty list.
		/// </summary>
		public PerformanceRepository()
		{
			if (File.Exists(_path))
			{
				LoadFromFile();
			}
			else
			{
				// If the file does not exist, create an empty file
				performances = new List<Performance>();
			}
		}

		public void Add(Performance performance)
		{
			performances.Add(performance);
			SaveToFile();
		}

		public void Delete(string performanceId)
		{
			foreach (Performance performance in performances)
			{
				// Find the performance with the matching `PerformanceId`, delete it from the list, and save the changes to the file
				if (performance.PerformanceId == performanceId)
				{
					performances.Remove(performance);
					SaveToFile();
					return;
				}
			}
		}

		public List<Performance> GetAll()
		{
			return performances;
		}

		public Performance GetById(string performanceId)
		{
			foreach (Performance performance in performances)
			{
				if (performance.PerformanceId == performanceId)
				{
					return performance;
				}
			}
			return null;
		}

		public List<Performance> Search(string searchTerm)
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

		public void Update(Performance performance)
		{
			for (int i = 0; i < performances.Count; i++)
			{
				// Find the performance with the matching `PerformanceId`
				if (performances[i].PerformanceId == performance.PerformanceId)
				{
					// Update the performance in the list and save the changes to the file
					performances[i] = performance;
					SaveToFile();
					return;
				}
			}
			throw new Exception("Performance not found");
		}

		/// <summary>
		/// Loads the list of performances from a JSON file. It reads the contents of the specified file path,
		/// deserializes the JSON string into a list of Performance objects, and assigns it to the performances field.
		/// </summary>
		private void LoadFromFile()
		{
			string json = File.ReadAllText(_path);
			performances = JsonSerializer.Deserialize<List<Performance>>(json);
		}

		/// <summary>
		/// Saves the current list of performances to a JSON file. It serializes the list of performances into a JSON string
		/// with indentation instead of compact formatting for readability and writes it to the specified file path.
		/// </summary>
		private void SaveToFile()
		{
			string json = JsonSerializer.Serialize(performances, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(_path, json);
		}
	}
}

using System.Text.Json;
using CircusLunaLibrary.Models;

namespace CircusLunaLibrary.Repositories
{
	public class PerformanceRepository : IPerformanceRepository
	{
		private readonly string path = Path.Combine("Data", "performances.json");
		private List<Performance> performances = new List<Performance>();

		/// <summary>
		/// Constructor for the PerformanceRepository class. It checks if the JSON file containing the performances exists.
		/// If it does, it loads the performances from the file using the LoadFromFile method.
		/// If the file does not exist, it creates a new file with an empty array and initializes the performances list as an empty list.
		/// </summary>
		public PerformanceRepository()
		{
			if (File.Exists(path))
			{
				LoadFromFile();
			}
			else
			{
				// If the file does not exist, create an empty file
				File.WriteAllText(path, "[]");
			}
		}

		public void Add(Performance performance)
		{
			throw new NotImplementedException();
		}

		public void Delete(string performanceId)
		{
			throw new NotImplementedException();
		}

		public List<Performance> GetAll()
		{
			throw new NotImplementedException();
		}

		public Performance GetById(string performanceId)
		{
			throw new NotImplementedException();
		}

		public void Update(Performance performance)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Loads the list of performances from a JSON file. It reads the contents of the specified file path,
		/// deserializes the JSON string into a list of Performance objects, and assigns it to the performances field.
		/// </summary>
		private void LoadFromFile()
		{
			string json = File.ReadAllText(path);
			performances = JsonSerializer.Deserialize<List<Performance>>(json);
		}

		/// <summary>
		/// Saves the current list of performances to a JSON file. It serializes the list of performances into a JSON string
		/// with indentation instead of compact formatting for readability and writes it to the specified file path.
		/// </summary>
		private void SaveToFile()
		{
			string json = JsonSerializer.Serialize(performances, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(path, json);
		}
	}
}

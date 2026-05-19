using System.Text.Json;
using CircusLunaLibrary.Models;

namespace CircusLunaLibrary.Repositories
{
	public class SeatRepository : ISeatRepository
	{
		private readonly string _path = Path.Combine("Data", "seats.json");
		private List<Seat> seats = new List<Seat>();

		public SeatRepository()
		{
			if (File.Exists(_path))
			{
				LoadFromFile();
			}
			else
			{
				// If the file does not exist, initialize the seats and create the file
				seats = InitializeSeats();
				SaveToFile();
			}
		}

		public List<Seat> GetAll()
		{
			return seats;
		}

		public Seat GetById(string seatId)
		{
			foreach (Seat seat in seats)
			{
				if (seat.SeatId == seatId)
				{
					return seat;
				}
			}
			return null;
		}

		/// <summary>
		/// Initializes the seats for the venue. The first row (A) is VIP, and the rest are standard.
		/// There are 15 rows (A to O) and 10 columns (1 to 10) for a total of 150 seats.
		/// </summary>
		private List<Seat> InitializeSeats()
		{
			List<Seat> seats = new List<Seat>();

			for (char i = 'A'; i <= 'O'; i++) // 15 rows (A to O)
			{
				for (int j = 1; j <= 10; j++) // 10 columns (1 to 10)
				{
					Seat newSeat = new Seat(i, j);

					// First row is VIP, the rest are standard
					if (i == 'A')
					{
						newSeat.SeatType = SeatType.VIP;
					}

					seats.Add(newSeat);
				}
			}
			return seats;
		}

		/// <summary>
		/// Loads the list of seats from a JSON file. It reads the contents of the specified file path,
		/// deserializes the JSON string into a list of Seat objects, and assigns it to the seats field.
		/// </summary>
		private void LoadFromFile()
		{
			string json = File.ReadAllText(_path);
			seats = JsonSerializer.Deserialize<List<Seat>>(json);
		}

		/// <summary>
		/// Saves the current list of seats to a JSON file. It serializes the list of seats into a JSON string
		/// with indentation instead of compact formatting for readability and writes it to the specified file path.
		/// </summary>
		private void SaveToFile()
		{
			string json = JsonSerializer.Serialize(seats, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(_path, json);
		}
	}
}

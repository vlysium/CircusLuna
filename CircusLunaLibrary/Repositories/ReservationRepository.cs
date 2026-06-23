using CircusLunaLibrary.Models;
using System.Text.Json;

namespace CircusLunaLibrary.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private List<Reservation> _reservations;
        private readonly string _filePath = Path.Combine("Data", "reservations.json");

        public ReservationRepository()
        {
            LoadFile();
        }
        public void LoadFile()
        {
            if (!File.Exists(_filePath))
            {
                _reservations = new List<Reservation>();
            }
            else
            {
                string json = File.ReadAllText(_filePath);
                _reservations = JsonSerializer.Deserialize<List<Reservation>>(json);
            }            
        }
        public void SaveFile()
        {

            string json = JsonSerializer.Serialize<List<Reservation>>(_reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath,json);
        }
        public void AddReservation(Reservation reservation)
        {
            LoadFile();
            _reservations.Add(reservation);
            SaveFile();
        }

        public void DeleteReservation(string id)
        {
            Reservation toBeDeleted = GetByID(id);
            _reservations.Remove(toBeDeleted);
            SaveFile();
        }

        public List<Reservation> GetAll()
        {
            LoadFile();
            return _reservations;
        }

        public Reservation GetByID(string id)
        {
            foreach(Reservation reservation in _reservations)
            {
                if (reservation.ReservationID == id)
                {
                    return reservation;
                }
            }
            return null;
        }

        public void UpdateReservation(string id, Reservation updatedReservation)
        {
            Reservation toBeUpdated = GetByID(id);
            toBeUpdated = updatedReservation;
        }
    }
}

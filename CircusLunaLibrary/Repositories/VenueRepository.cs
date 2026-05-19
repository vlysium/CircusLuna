using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CircusLunaLibrary.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private string _filePath = Path.Combine("Data", "venues.json");
        private List<Venue> _venues;

        public VenueRepository()
        {
            
             LoadAndFixVenues();
           
        }

        public void LoadAndFixVenues()
        {
            try
            {
                // 1. If the file exists, read it
                if (File.Exists(_filePath))
                {
                    string jsonString = File.ReadAllText(_filePath);
                    _venues = JsonSerializer.Deserialize<List<Venue>>(jsonString) ?? new List<Venue>();
                }

                // 2. If the file was empty or missing, create default venues using the correct constructor
                if (_venues == null || _venues.Count == 0)
                {
                    _venues = new List<Venue>
                {
                    new Venue("RegnbueTeltet", 10, 140),
                    new Venue("Solstrålen", 10, 70)
                };
                }

                // 3. FORCE FIX ANY NULLS OR EMPTY LISTS IN MEMORY
                foreach (var venue in _venues)
                {
                    // If ID is missing, force-generate it right now
                    if (string.IsNullOrWhiteSpace(venue.ID))
                    {
                        venue.ID = Guid.NewGuid().ToString().Substring(0, 8);
                    }

                    // If Seats list is empty or null, force-populate it right now
                    if (venue.Seats == null || venue.Seats.Count == 0)
                    {
                        venue.InitializeSeats();
                    }
                }

                // 4. IMMEDIATELY OVERWRITE THE BAD JSON FILE WITH THE FIXED DATA
                SaveFile();
            }
            catch (Exception ex)
            {
                // Fallback in case the JSON file is corrupted and cannot be parsed
                _venues = new List<Venue>
            {
                new Venue("RegnbueTeltet", 10, 140),
                new Venue("Solstrålen", 10, 70)
            };
                SaveFile();
            }
        }
        public void LoadFile()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                _venues = JsonSerializer.Deserialize<List<Venue>>(json);
            }
            else
            {
                _venues = new List<Venue>();
            }
        }

        public void SaveFile()
        {
            Console.WriteLine("JSON is saving to: " + Path.GetFullPath(_filePath));
            string json = JsonSerializer.Serialize<List<Venue>>(_venues);
            File.WriteAllText(_filePath, json);
        }
        public void AddVenue(Venue venue)
        {
            _venues.Add(venue);
            SaveFile();
        }

        public void DeleteVenue(Venue venue)
        {
            _venues.Remove(venue);
            SaveFile();
        }

        public List<Venue> GetAll()
        {
            return _venues;
        }

        public List<Seat> GetAllSeats(string venueId)
        {
            Venue v = GetById(venueId);
            return v.Seats;
        }

        public Venue GetById(string id)
        {
            foreach(Venue v in _venues)
            {
                if (v.ID == id)
                {
                    if (v.Seats == null)
                    {
                        // Force the seats to generate if they were not stored in the database
                        v.InitializeSeats();
                    }
                    return v;
                }
            }
            return null;
        }

        public Seat GetSeatById(string venueId, string seatId)
        {
            Venue v = GetById(venueId);
            List<Seat> seats = v.Seats;
            foreach(Seat s in seats)
            {
                if (s.SeatId == seatId)
                {
                    return s;
                }
            }
            return null;
        }
    }
}

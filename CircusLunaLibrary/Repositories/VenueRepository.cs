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
                // 1. If the file exists, load normally:
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    _venues = JsonSerializer.Deserialize<List<Venue>>(json) ?? new List<Venue>();
                }

                // 2. If the file was empty or missing, create default venues using the correct constructor
                if (_venues == null || _venues.Count == 0)
                {
                    _venues = new List<Venue>
                {
                    new Venue("RegnbueTeltet", 10, 140),
                    new Venue("Solstrålen", 10, 70),
                    new Venue("RC", 10, 12)
                };
                }

                // 3. FORCE FIX ANY NULLS OR EMPTY LISTS IN MEMORY
                foreach (var venue in _venues)
                {
                    if (string.IsNullOrWhiteSpace(venue.ID))
                    {
                        venue.ID = Guid.NewGuid().ToString().Substring(0, 8);
                    }

                    if (venue.Seats == null || venue.Seats.Count == 0)
                    {
                        venue.InitializeSeats();
                    }
                }
                SaveFile();
            }
            catch (Exception ex)
            {
                // Fallback in case the JSON file is corrupted and cannot be parsed
                Console.WriteLine($"Critical Error: {ex}");
                _venues = new List<Venue>
            {
                new Venue("RegnbueTeltet", 10, 140),
                new Venue("Solstrålen", 10, 70),
                new Venue("RC", 10, 12)
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
            string json = JsonSerializer.Serialize<List<Venue>>(_venues, new JsonSerializerOptions { WriteIndented = true });
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
        public void UpdateVenue(Venue venue)
        {
            foreach(Venue v in _venues)
            {
                if (v.ID == venue.ID)
                {
                    v.Name = venue.Name;
                    v.VipSeats = venue.VipSeats;
                    v.StandardSeats = venue.StandardSeats;
                    v.InitializeSeats();
                }
            }
        }
    }
}

using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Repositories
{
    public class VenueRepository : IVenueRepository
    {
        private string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "venues.json");
        private Venue _venue;
        public VenueRepository()
        {
            LoadFile();
        }
        public void LoadFile()
        {
            if (!File.Exists(_filePath))
            {
                _venue = new Venue();
            }
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() },
                PropertyNameCaseInsensitive = true // Highly recommended to avoid casing issues
            };
            string json = File.ReadAllText(_filePath);
            _venue = JsonSerializer.Deserialize<Venue>(json, options);
        }

        public void SaveFile()
        {
            string json = JsonSerializer.Serialize<Venue>(_venue);
            File.WriteAllText(_filePath, json);
        }
        public Venue GetVenue()
        {
            return _venue;
        }
     
        public void EditVenue(Venue venue)
        {
            _venue.Name = venue.Name;            
        }
    }
}

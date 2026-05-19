using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Repositories
{
    public interface IVenueRepository
    {
        public void LoadAndFixVenues();
        public List<Venue> GetAll();
        public Venue GetById(string id);
        public List<Seat> GetAllSeats(string venueId);
        public Seat GetSeatById(string venueId, string seatId);
        public void AddVenue(Venue venue);
        public void DeleteVenue(Venue venue);
    }
}

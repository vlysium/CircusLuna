using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Services
{
    public class VenueService
    {
        private readonly IVenueRepository _repository;
        private Venue _venue;
        public VenueService(IVenueRepository repo)
        {
            _repository = repo;
        }
           
        public Venue GetVenue()
        {            
            return _repository.GetVenue();
        }
        public List<Seat> GetAllSeats()
        {
            return _repository.GetVenue().AllSeats;
        }
    }
}

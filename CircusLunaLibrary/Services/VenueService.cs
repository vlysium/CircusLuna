using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Services
{
    
    
    public class VenueService
    {
        private readonly IVenueRepository _venueRepository;
        private List<Venue> _venues;

        public VenueService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
            _venueRepository.LoadAndFixVenues();
        }

        public void AddVenue(Venue venue)
        {
            _venueRepository.AddVenue(venue);
        }
        public List<Venue> GetAll()
        {
            return _venueRepository.GetAll();
        }
        public Venue GetById(string venueId)
        {
            return _venueRepository.GetById(venueId);
            
        }


    }
}

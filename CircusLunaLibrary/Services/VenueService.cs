using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Services
{
    /// <summary>
    /// Service layer responsible for processing domain logic surrounding circus venues.
    /// Acts as an intermediary between the presentation layer and the venue data repository,
    /// ensuring structural venue configurations are initialized and accessible.
    /// </summary>
    public class VenueService
    {
        private readonly IVenueRepository _venueRepository;
        private List<Venue> _venues;

        /// <summary>
        /// Initializes a new instance of the <see cref="VenueService"/> class.
        /// Automatically triggers a data refresh and structure-integrity routine on the backing store.
        /// </summary>
        /// <param name="venueRepository">The data repository interface used to persist and retrieve venue records.</param>
        public VenueService(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
            _venueRepository.LoadAndFixVenues();
        }

        /// <summary>
        /// Registers a brand new physical venue configuration profile within the system.
        /// </summary>
        /// <param name="venue">The concrete <see cref="Venue"/> entity detailing structural setup and capacities.</param>
        public void AddVenue(Venue venue)
        {
            _venueRepository.AddVenue(venue);
        }

        /// <summary>
        /// Compiles a global listing containing every registered circus venue profile found in storage.
        /// </summary>
        /// <returns>A tracking <see cref="List{Venue}"/> of configured showgrounds.</returns>
        public List<Venue> GetAll()
        {
            return _venueRepository.GetAll();
        }

        /// <summary>
        /// Locates a specific structural venue configuration matching the given identifier key.
        /// </summary>
        /// <param name="venueId">The unique lookup string identity of the venue record.</param>
        /// <returns>The matched <see cref="Venue"/> domain instance; otherwise, returns <see langword="null"/> if no matching record is found.</returns>
        public Venue GetById(string venueId)
        {
            return _venueRepository.GetById(venueId);
        }
    }
}
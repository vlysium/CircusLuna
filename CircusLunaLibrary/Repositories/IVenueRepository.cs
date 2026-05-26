using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Repositories
{
    /// <summary>
    /// Defines the data access contract for managing physical circus venues and structural seat layouts.
    /// Provides data parsing, standard CRUD capabilities, and deep-query granularity for individual seating allocations.
    /// </summary>
    public interface IVenueRepository
    {
        /// <summary>
        /// Loads venue data configurations from persistent storage and executes integrity fixes 
        /// to repair or standardize corrupt layout schemas.
        /// </summary>
        public void LoadAndFixVenues();

        /// <summary>
        /// Retrieves the entire collection of registered structural venues.
        /// </summary>
        /// <returns>A tracking <see cref="List{Venue}"/> containing all configured venue entities.</returns>
        public List<Venue> GetAll();

        /// <summary>
        /// Locates a specific venue configuration profile matching the given identifier key.
        /// </summary>
        /// <param name="id">The unique lookup identity string of the venue.</param>
        /// <returns>The matched <see cref="Venue"/> domain instance; otherwise, returns <see langword="null"/> if no matching record is found.</returns>
        public Venue GetById(string id);

        /// <summary>
        /// Extracts and compiles the complete collection of physical structural seats configured within a specified venue layout.
        /// </summary>
        /// <param name="venueId">The unique lookup identifier of the target venue housing the seats.</param>
        /// <returns>A flat <see cref="List{Seat}"/> containing all physical seats bound to the venue.</returns>
        public List<Seat> GetAllSeats(string venueId);

        /// <summary>
        /// Locates a highly specific seating structure token relative to an explicit venue coordinate layout.
        /// </summary>
        /// <param name="venueId">The unique lookup identity of the target host venue.</param>
        /// <param name="seatId">The distinct sub-identifier key assigned to the physical target seat location.</param>
        /// <returns>The localized structural <see cref="Seat"/> profile object configuration mapping.</returns>
        public Seat GetSeatById(string venueId, string seatId);

        /// <summary>
        /// Commits and writes a brand new structural venue configuration profile to the data layer tracking collection.
        /// </summary>
        /// <param name="venue">The concrete <see cref="Venue"/> object metadata instance containing structural definitions to record.</param>
        public void AddVenue(Venue venue);

        /// <summary>
        /// Removes a tracking venue record along with its underlying data layers permanently from the data persistence layer.
        /// </summary>
        /// <param name="venue">The concrete structural <see cref="Venue"/> entity tracking to remove.</param>
        public void DeleteVenue(Venue venue);

        /// <summary>
        /// Overwrites and updates capacity mappings or name values for an established structural venue entry.
        /// </summary>
        /// <param name="venue">The modified structural <see cref="Venue"/> entity instance tracking modern field values to sync.</param>
        public void UpdateVenue(Venue venue);
    }
}
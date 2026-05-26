using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Repositories
{
    /// <summary>
    /// Defines the data access contract for managing seat and ticket reservations.
    /// Provides structural methods for file-based lifecycle operations alongside standard CRUD capabilities.
    /// </summary>
    public interface IReservationRepository
    {
        /// <summary>
        /// Flushes and writes the active collection of reservations from memory back into the underlying file storage.
        /// </summary>
        public void SaveFile();

        /// <summary>
        /// Loads reservation records from the underlying file store into the active application memory.
        /// </summary>
        public void LoadFile();

        /// <summary>
        /// Retrieves the entire collection of processed circus reservations.
        /// </summary>
        /// <returns>A tracking <see cref="List{Reservation}"/> containing all recorded booking data.</returns>
        public List<Reservation> GetAll();

        /// <summary>
        /// Locates a specific booking transaction record matching the given identifier key.
        /// </summary>
        /// <param name="id">The unique transaction identity string of the reservation record.</param>
        /// <returns>The matched <see cref="Reservation"/> domain instance; otherwise, returns <see langword="null"/> if no matching record is found.</returns>
        public Reservation GetByID(string id);

        /// <summary>
        /// Commits and writes a new reservation aggregate profile to the data layer.
        /// </summary>
        /// <param name="reservation">The concrete <see cref="Reservation"/> object instance detailing seats, customer, and performance.</param>
        public void AddReservation(Reservation reservation);

        /// <summary>
        /// Removes an existing reservation transaction record from data persistence tracking.
        /// </summary>
        /// <param name="id">The unique tracking token identity of the reservation to remove.</param>
        public void DeleteReservation(string id);

        /// <summary>
        /// Overwrites and updates active booking fields for a specific scheduled reservation entry.
        /// </summary>
        /// <param name="id">The stable reference identity key of the target reservation to update.</param>
        /// <param name="reservation">The data container holding the modern field values to apply.</param>
        public void UpdateReservation(string id, Reservation reservation);
    }
}
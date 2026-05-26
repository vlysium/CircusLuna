using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Repositories
{
    /// <summary>
    /// Defines the data access contract for managing customers and employees in the system.
    /// Provides methods for persistence lifecycle operations (loading/saving) alongside standard CRUD functional capabilities.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Loads person records from the underlying data store file into the active application memory.
        /// </summary>
        public void LoadFile();

        /// <summary>
        /// Flushes and writes the active collection of person records from memory back into the underlying data store file.
        /// </summary>
        public void SaveFile();

        /// <summary>
        /// Retrieves the entire collection of registered people profiles.
        /// </summary>
        /// <returns>A tracking <see cref="List{Person}"/> containing all managed people data records.</returns>
        public List<Person> GetAll();

        /// <summary>
        /// Registers and writes a new person domain entity to the persistence layer storage cache.
        /// </summary>
        /// <param name="person">The concrete <see cref="Person"/> object metadata instance to record.</param>
        public void AddPerson(Person person);

        /// <summary>
        /// Removes an existing person entity from the underlying data persistence collection.
        /// </summary>
        /// <param name="id">The unique token identity lookup value of the person to scrub.</param>
        public void DeletePerson(string id);

        /// <summary>
        /// Overwrites and updates properties for a specific targeted person entity index.
        /// </summary>
        /// <param name="id">The original stable reference identity key of the target person to modify.</param>
        /// <param name="updatedPerson">The data container tracking the modern field values to apply.</param>
        public void UpdatePerson(string id, Person updatedPerson);

        /// <summary>
        /// Locates a specific individual profile object record matching the given identifier key.
        /// </summary>
        /// <param name="id">The unique lookup string identity of the person record.</param>
        /// <returns>The matched <see cref="Person"/> domain instance; otherwise, returns <see langword="null"/> if no matching record is found.</returns>
        public Person GetById(string id);
    }
}
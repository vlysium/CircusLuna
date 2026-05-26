using System;
using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents a geographic city or municipality entity within the system.
    /// Tracks localized postal codes and region classifications while maintaining a unique identifier.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Gets or sets the unique alphanumeric identity code for the city.
        /// Generated automatically as a shortened unique tracking token upon initialization.
        /// </summary>
        public string CityID { get; set; }

        /// <summary>
        /// Gets or sets the name of the city or municipality.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the postal or ZIP sorting code associated with the city area.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the broader geographic territory or jurisdiction enum value where the city resides.
        /// This property is optional and can be <see langword="null"/>.
        /// </summary>
        public Region? Region { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class with a unique identifier.
        /// Annotated with <see cref="JsonConstructorAttribute"/> to serve as the primary entry point for JSON deserialization frameworks.
        /// </summary>
        [JsonConstructor]
        public City()
        {
            CityID = Guid.NewGuid().ToString().Substring(0, 8);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class with explicit geographic location metrics.
        ///
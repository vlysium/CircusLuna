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
        /// Chains to the default parameterless constructor to automatically establish a unique tracking identifier.
        /// </summary>
        /// <param name="name">The name of the city or municipality.</param>
        /// <param name="postalCode">The postal or ZIP sorting code associated with the city area.</param>
        /// <param name="region">The broader geographic territory or jurisdiction enum value.</param>
        public City(string name, string postalCode, Region region) : this()
        {
            Name = name;
            PostalCode = postalCode;
            Region = region;
        }

        /// <summary>
        /// Returns a formatted string representation combining the city name, postal code, and region context.
        /// </summary>
        /// <returns>A single-line textual data mapping string containing the localized location details.</returns>
        public override string ToString()
        {
            return $"{Name} {PostalCode} {Region}";
        }
    }
}
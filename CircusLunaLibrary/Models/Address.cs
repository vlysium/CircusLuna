using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents a physical mailing or structural location address.
    /// Used across the domain to track site locations and personnel contact coordinates.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the primary street address line (e.g., street name and house number).
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the secondary address details, such as apartment, suite, or unit number.
        /// This property is optional and can be <see langword="null"/>.
        /// </summary>
        public string? AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the postal or ZIP routing code for the location area.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city or municipality name.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class with default empty values.
        /// </summary>
        public Address()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class with explicit location details.
        /// </summary>
        /// <param name="addressLine1">The primary street address line.</param>
        /// <param name="addressLine2">The optional secondary address information (apartment, suite, etc.).</param>
        /// <param name="postalCode">The postal or ZIP routing code.</param>
        /// <param name="city">The city or municipality name.</param>
        public Address(string addressLine1, string addressLine2, string postalCode, string city)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            PostalCode = postalCode;
            City = city;
        }

        /// <summary>
        /// Returns a formatted string representation of the complete address.
        /// Dynamically handles omitting the optional second address line if it is empty or whitespace.
        /// </summary>
        /// <returns>A multiline string containing the formatted physical address block.</returns>
        public override string ToString()
        {
            string secondLine = string.IsNullOrWhiteSpace(AddressLine2) ? "" : $"{AddressLine2}\n";
            return $"{AddressLine1} {secondLine}{PostalCode} {City}";
        }
    }
}
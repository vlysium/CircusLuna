using System.Net;
using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents the abstract base class for all human entities within the circus registry system.
    /// Configured with polymorphic JSON serialization metadata to correctly handle inheritance structures 
    /// for derived classes during data persistence operations.
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Customer), typeDiscriminator: "customer")]
    [JsonDerivedType(typeof(Employee), typeDiscriminator: "employee")]
    [JsonDerivedType(typeof(Artist), typeDiscriminator: "artist")]
    public abstract class Person
    {
        /// <summary>
        /// Gets or sets the unique alphanumeric identification string for the person.
        /// Generated automatically as a shortened unique tracking token upon initialization.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the full legal or public-facing name of the individual.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the contact telephone number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the physical mailing or residential address structure.
        /// This property is optional and can be <see langword="null"/>.
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Gets or sets the electronic mail communication address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// Automatically derives an 8-character string token identity using a truncated <see cref="Guid"/>.
        /// </summary>
        public Person()
        {
            ID = Guid.NewGuid().ToString().Substring(0, 8);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with explicit contact information,
        /// while defaulting structural residency values to <see langword="null"/>.
        /// Chains to the default parameterless constructor to establish a unique tracking identifier.
        /// </summary>
        /// <param name="name">The full name of the individual.</param>
        /// <param name="number">The contact telephone number.</param>
        /// <param name="email">The electronic mail communication address.</param>
        public Person(string name, string number, string email)
            : this()
        {
            Name = name;
            Number = number;
            Email = email;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class with comprehensive profile attributes,
        /// including a physical residency contact address.
        /// </summary>
        /// <param name="name">The full name of the individual.</param>
        /// <param name="number">The contact telephone number.</param>
        /// <param name="email">The electronic mail communication address.</param>
        /// <param name="address">The structural physical mailing address record mapping.</param>
        public Person(string name, string number, string email, Address address)
            : this(name, number, email)
        {
            Address = address;
        }

        /// <summary>
        /// Returns a formatted string representation of the core profile fields.
        /// </summary>
        /// <returns>A multiline text block summarizing the profile identity data and contact methods.</returns>
        public override string ToString()
        {
            return $"ID: {ID}. \nNavn: {Name}. \nNummer: {Number}. \nAddresse: {Address}. \nEmail: {Email}";
        }
    }
}
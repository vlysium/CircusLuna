using System.Net;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents a circus patron, ticket buyer, or external client entity.
    /// Inherits basic contact registration fields from the base <see cref="Person"/> model.
    /// </summary>
    public class Customer : Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with default empty values.
        /// </summary>
        public Customer() : base() { }

        //public List<Reservation> Reservations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with comprehensive profile attributes, 
        /// including a physical residency contact address.
        /// </summary>
        /// <param name="name">The full name of the customer.</param>
        /// <param name="number">The telephone contact number.</param>
        /// <param name="email">The digital mail communication address.</param>
        /// <param name="address">The structural physical mailing address record mapping.</param>
        public Customer(string name, string number, string email, Address address)
            : base(name, number, email, address)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class with explicit identity strings 
        /// while defaulting structural residency values to <see langword="null"/>.
        /// </summary>
        /// <param name="name">The full name of the customer.</param>
        /// <param name="number">The telephone contact number.</param>
        /// <param name="email">The digital mail communication address.</param>
        public Customer(string name, string number, string email)
            : base(name, number, email, null)
        {
        }

        /// <summary>
        /// Returns a formatted string representation identifying the record explicitly as a customer 
        /// along with inherited personal contact details.
        /// </summary>
        /// <returns>A string summary prefixed with the classification type.</returns>
        public override string ToString()
        {
            return $"Customer - {base.ToString()}";
        }
    }
}
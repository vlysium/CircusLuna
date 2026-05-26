using CircusLunaLibrary.Models;
using System.Net;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents a circus performer or specialist entity.
    /// Inherits from the base <see cref="Employee"/> class, extending it with 
    /// contract duration track indicators unique to independent contract or staff artists.
    /// </summary>
    public class Artist : Employee
    {
        /// <summary>
        /// Gets or sets a value indicating whether the artist has a permanent staff contract 
        /// rather than a temporary seasonal tour contract.
        /// </summary>
        public bool IsPermanent { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Artist"/> class with default empty values.
        /// </summary>
        public Artist() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Artist"/> class with comprehensive profile attributes, 
        /// including physical residency contact addresses.
        /// </summary>
        /// <param name="paymentinfo">The bank routing or financial settlement data for payroll processing.</param>
        /// <param name="role">The specialty performance designation or job title of the artist (e.g., Acrobat, Juggler).</param>
        /// <param name="isPermanent">A flag indicating contract permanence status.</param>
        /// <param name="name">The legal or public-facing stage name of the individual.</param>
        /// <param name="number">The telephone contact number.</param>
        /// <param name="email">The digital mail communication address.</param>
        /// <param name="address">The structural physical mailing address record mapping.</param>
        public Artist(string paymentinfo, string role, bool isPermanent, string name, string number, string email, Address address)
            : base(paymentinfo, role, name, number, email, address)
        {
            IsPermanent = isPermanent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Artist"/> class with explicit contact 
        /// metadata fields while defaulting structural residency values to <see langword="null"/>.
        /// </summary>
        /// <param name="paymentinfo">The bank routing or financial settlement data for payroll processing.</param>
        /// <param name="role">The specialty performance designation or job title of the artist (e.g., Acrobat, Juggler).</param>
        /// <param name="isPermanent">A flag indicating contract permanence status.</param>
        /// <param name="name">The legal or public-facing stage name of the individual.</param>
        /// <param name="number">The telephone contact number.</param>
        /// <param name="email">The digital mail communication address.</param>
        public Artist(string paymentinfo, string role, bool isPermanent, string name, string number, string email)
            : base(paymentinfo, role, name, number, email, null)
        {
            IsPermanent = isPermanent;
        }

        /// <summary>
        /// Returns a formatted string representation combining basic employee registry data metrics 
        /// with specific contractual artist tracking variables.
        /// </summary>
        /// <returns>A multiline string block summary outlining identity data and contract permanence states.</returns>
        public override string ToString()
        {
            return $"{base.ToString()}\nPermanent:{IsPermanent}";
        }
    }
}
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents an internal, formal circus staff member or employee entity.
    /// Inherits basic identity fields from the base <see cref="Person"/> class, 
    /// extending it with administrative payroll details and functional job assignments.
    /// </summary>
    public class Employee : Person
    {
        /// <summary>
        /// Gets or sets the bank routing, account number, or financial settlement data used for payroll processing.
        /// </summary>
        public string PaymentInfo { get; set; }

        /// <summary>
        /// Gets or sets the formal organizational role, position, or job title assigned to the employee.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class with default empty values.
        /// </summary>
        public Employee() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class with comprehensive profile attributes,
        /// including administrative records and a physical residency contact address.
        /// </summary>
        /// <param name="paymentinfo">The bank routing or financial settlement data used for payroll processing.</param>
        /// <param name="role">The formal organizational role, position, or job title assigned to the employee.</param>
        /// <param name="name">The legal or public-facing name of the individual.</param>
        /// <param name="number">The telephone contact number.</param>
        /// <param name="email">The digital mail communication address.</param>
        /// <param name="address">The structural physical mailing address record mapping.</param>
        public Employee(string paymentinfo, string role, string name, string number, string email, Address address)
            : base(name, number, email, address)
        {
            Role = role;
            PaymentInfo = paymentinfo;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class with explicit tracking fields 
        /// while defaulting structural residency values to <see langword="null"/>.
        /// </summary>
        /// <param name="paymentinfo">The bank routing or financial settlement data used for payroll processing.</param>
        /// <param name="role">The formal organizational role, position, or job title assigned to the employee.</param>
        /// <param name="name">The legal or public-facing name of the individual.</param>
        /// <param name="number">The telephone contact number.</param>
        /// <param name="email">The digital mail communication address.</param>
        public Employee(string paymentinfo, string role, string name, string number, string email)
            : this(paymentinfo, role, name, number, email, null)
        {
        }

        /// <summary>
        /// Returns a formatted string representation combining basic identity metrics with 
        /// operational corporate employee tracking fields.
        /// </summary>
        /// <returns>A multiline string summary outlining contact profile details, company role, and payment parameters.</returns>
        public override string ToString()
        {
            return $"{base.ToString()}\nRole: {Role}\nPaymentInfo: {PaymentInfo}";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Represents a customer booking transaction for a specific circus show.
    /// Manages structural connections between the purchasing customer, the targeted show performance, 
    /// the group of itemized tickets, and the computed transactional total price.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Gets or sets the unique alphanumeric identifier code for the reservation transaction.
        /// Generated automatically as a shortened unique tracking token upon initialization.
        /// </summary>
        public string ReservationID { get; set; }

        /// <summary>
        /// Gets or sets the purchasing patron profile data bound to this booking.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the specific scheduled show event or performance information for this booking.
        /// </summary>
        public Performance Performance { get; set; }

        /// <summary>
        /// Gets or sets the collection of itemized tickets containing explicit seat allocations and pricing tiers.
        /// </summary>
        public List<Ticket> Tickets { get; set; }

        /// <summary>
        /// Gets or sets the total combined financial cost computed for all tickets bound to this reservation.
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation"/> class.
        /// Automatically derives an 8-character string token identity using a truncated <see cref="Guid"/>.
        /// </summary>
        public Reservation()
        {
            ReservationID = Guid.NewGuid().ToString().Substring(0, 8);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation"/> class with explicit booking relationships.
        /// Chains to the default parameterless constructor to automatically establish a unique tracking identifier 
        /// and evaluates the total purchase cost immediately.
        /// </summary>
        /// <param name="customer">The purchasing patron profile data bound to this booking.</param>
        /// <param name="performance">The specific scheduled show event or performance information.</param>
        /// <param name="tickets">The collection of individual ticket allocations assigned to this transaction.</param>
        public Reservation(Customer customer, Performance performance, List<Ticket> tickets) : this()
        {
            Customer = customer;
            Performance = performance;
            Tickets = tickets;
            TotalPrice = GetTotalPrice();
        }

        /// <summary>
        /// Calculates the total transactional cost by accumulating individual unit line pricing values from the attached ticket tracking collection.
        /// </summary>
        /// <returns>The calculated sum total financial cost of the reservation collection.</returns>
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach (Ticket t in Tickets)
            {
                totalPrice += t.Price;
            }
            return totalPrice;
        }

        /// <summary>
        /// Returns a formatted string summary combining transaction identity values, show data properties, 
        /// and a comma-delimited string enumeration of all bound tickets.
        /// </summary>
        /// <returns>A multiline string summarizing structural reservation attributes optimized for display views.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Tickets.Count; i++)
            {
                sb.Append(Tickets[i]);
                if (i < Tickets.Count - 1) sb.Append(", ");
            }
            return $"ReservationsID: {ReservationID}\nForestilling: {Performance}\nBiletter: {sb.ToString()}";
        }
    }
}
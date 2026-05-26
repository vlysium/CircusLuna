namespace CircusLunaLibrary.Models
{
    /// <summary>
    /// Specifies the demographic classification or tier pricing privilege of a ticket.
    /// This tier works in conjunction with the structural physical seat selection to determine final ticket costs.
    /// </summary>
    public enum TicketType
    {
        /// <summary>
        /// Represents a standard admission tier for adult patrons with normal pricing metrics.
        /// </summary>
        Standard,

        /// <summary>
        /// Represents an elevated privilege tier that grants access to premium services and introduces fixed base price surcharges.
        /// </summary>
        VIP,

        /// <summary>
        /// Represents a child admission tier (Danish: "Barn") that applies special promotional discount rates when paired with standard seating layouts.
        /// </summary>
        Barn
    }
}
using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace CircusLunaLibrary.Services
{
    /// <summary>
    /// Service layer responsible for processing business domain rules surrounding ticket bookings.
    /// Handles verifying dynamic seat availability and compiling ticket structures for circus performances.
    /// </summary>
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly VenueService _venueService;
        private List<Reservation> _reservations = new List<Reservation>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationService"/> class.
        /// </summary>
        /// <param name="repository">The data repository interface used to persist and retrieve reservation entries.</param>
        /// <param name="venueService">The service used to check physical seating arrays within specific show venues.</param>
        public ReservationService(IReservationRepository repository, VenueService venueService)
        {
            _reservationRepository = repository;
            
            _venueService = venueService;
        }

        /// <summary>
        /// Gathers a collection of all seat identifiers that have already been booked for a specific scheduled show.
        /// </summary>
        /// <param name="performanceID">The unique identifier token of the targeted performance.</param>
        /// <returns>A flat <see cref="List{String}"/> containing structural seat coordinates that are currently occupied.</returns>
        public List<string> GetBusySeatIds(string performanceID)
        {
            _reservations = _reservationRepository.GetAll();
            List<string> busySeatIds = new List<string>();
            for (int i = 0; i < _reservations.Count; i++)
            {
                if (_reservations[i].Performance.PerformanceId == performanceID)
                {
                    foreach (Ticket t in _reservations[i].Tickets)
                    {
                        busySeatIds.Add(t.Seat.SeatId);
                    }
                }
            }
            return busySeatIds;
        }

        /// <summary>
        /// Adds a verified booking reservation aggregate to data storage.
        /// </summary>
        /// <param name="reservation">The concrete <see cref="Reservation"/> entity detailing seats, tickets, and customer tracking metadata.</param>
        public void AddReservation(Reservation reservation)
        {
            _reservationRepository.AddReservation(reservation);
        }

        /// <summary>
        /// Cancels and deletes an established booking record permanently from data storage.
        /// </summary>
        /// <param name="id">The unique identifier key tracking the reservation transaction.</param>
        public void DeleteReservation(string id)
        {
            _reservationRepository.DeleteReservation(id);
        }

        /// <summary>
        /// Updates the attributes of a previously tracked reservation record.
        /// </summary>
        /// <param name="id">The original stable tracking identity token to overwrite.</param>
        /// <param name="reservation">The data container tracking the modern properties to persist.</param>
        public void UpdateReservation(string id, Reservation reservation)
        {
            _reservationRepository.UpdateReservation(id, reservation);
        }

        /// <summary>
        /// Cross-references flat coordinate strings with structural venue layout definitions to construct individual itemized ticket instances.
        /// </summary>
        /// <param name="VenueId">The unique identifier of the host venue providing the physical layout context.</param>
        /// <param name="SeatIds">The list of distinct seat labels selected by the customer.</param>
        /// <param name="TicketTypeString">The pricing category or tier requested for the ticket selection.</param>
        /// <returns>A collection of structural <see cref="Ticket"/> models mapped against concrete seat instances.</returns>
        public List<Ticket> CreateTickets(string VenueId, List<string> SeatIds, string TicketTypeString, string performanceId)
        {
            TicketType TicketTypeEnum = StringToTicketType(TicketTypeString);
            Venue venue = _venueService.GetById(VenueId);
            List<Ticket> tickets = new List<Ticket>();
            List<string> busySeatIds = new List<string>();

            busySeatIds = GetBusySeatIds(performanceId);

            foreach (string seatId in SeatIds)
            {
                if (busySeatIds.Contains(seatId)){
                    throw new InvalidOperationException("De valgte biletter er optagede, vælg venligst nye siddepladser");
                }
                
                foreach (Seat s in venue.Seats)
                {
                    if (s.SeatId == seatId)
                    {
                        Ticket t = new Ticket(TicketTypeEnum, s);
                        tickets.Add(t);
                        break;
                    }
                }
            }
            return tickets;
        }

        /// <summary>
        /// Parses incoming text categories into their matching runtime enumeration structure safely.
        /// </summary>
        /// <param name="TicketTypeString">The raw string data value describing the seat tier selection.</param>
        /// <returns>The resolved <see cref="TicketType"/> flag; defaults to <see cref="TicketType.Standard"/> if the input matches nothing.</returns>
        public TicketType StringToTicketType(string TicketTypeString)
        {
            if (!Enum.TryParse(TicketTypeString, out TicketType TicketTypeEnum))
            {
                TicketTypeEnum = TicketType.Standard; // Default fallback
            }
            return TicketTypeEnum;
        }
    }
}
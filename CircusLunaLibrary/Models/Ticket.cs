namespace CircusLunaLibrary.Models
{
    public class Ticket
    {
        public string TicketID { get; set; }
        public TicketType Type { get; set; }
        public Seat Seat { get; set; }
        public double Price { get; set; }


        public Ticket(TicketType type, Seat seat)
        {
            TicketID = Guid.NewGuid().ToString().Substring(0, 8);
            Type = type;
            Seat = seat;
        }
        public override string ToString()
        {
            return $"BilletID: {TicketID} | Billettype: {Type} | Siddeplads: {Seat.SeatRow}{Seat.SeatColumn}";
        }
    }
}
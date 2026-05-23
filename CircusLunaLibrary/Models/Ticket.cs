namespace CircusLunaLibrary.Models
{
    public class Ticket
    {
        public const double standardPrice = 150;
        public const double VIPprice = 200;
        public string TicketID { get; set; }
        public TicketType Type { get; set; }
        public Seat Seat { get; set; }
        public double Price { get; set; }


        public Ticket(TicketType type, Seat seat)
        {
            TicketID = Guid.NewGuid().ToString().Substring(0, 8);
            Type = type;
            Seat = seat;
            Price = CalculatePrice();
        }
        public double CalculatePrice()
        {
            double price = 0;
            if (Seat.SeatType == SeatType.Standard)
            {
                price += standardPrice;
            }
            if(Seat.SeatType == SeatType.VIP)
            {
                price += VIPprice;
            }
            if (Type == TicketType.VIP)
            {
                price += 50;
            }
            if (Type == TicketType.Barn && Seat.SeatType==SeatType.Standard)
            {
                price = price*0.7;
            }
            return price;
        }
        public override string ToString()
        {
            return $"BilletID: {TicketID} | Billettype: {Type} | Siddeplads: {Seat.SeatRow}{Seat.SeatColumn}";
        }
    }
}
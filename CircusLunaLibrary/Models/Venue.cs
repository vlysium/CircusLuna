using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Models
{
    public class Venue
    {
        public int MaxSeats { get; set; }
        public List<Seat> AllSeats { get; private set; } = new List<Seat>();
        public string Name { get; set; }

        public Venue(string name, int maxSeats)
        {
            Name = name;
            MaxSeats = maxSeats;
            InitializeSeats();
        }
        public void InitializeSeats()
        {
            int seatsPerRow = 10;
            for(int i = 0; i < MaxSeats; i++)
            {
                char charRow = (char)('A'+ (i / seatsPerRow)); //TYPE CASTING: computeren ser chars som tal. Derfor A+1=B. (char) er typecasting. Vi caster tallet til en char efter udregningen.
                int seatNumber = (i % seatsPerRow)+1;  //MODULUS: Vi tager det, der er tilbage. 0/10=0+1 -> nr 1. 5/10=5+1 -> nr 6. 27/10=7+1 -> nr 8 osv. Ignorer 10'erne som udgør ROWS.
                if (charRow == 'A')
                {
                    AllSeats.Add(new Seat(charRow, seatNumber, SeatType.VIP));
                }
                else
                {
                    AllSeats.Add(new Seat(charRow, seatNumber, SeatType.standard));
                }
            }
        }
        public override string ToString()
        {
            return $"Teltet {Name} indeholder {MaxSeats} standardsiddepladser og 10 VIP pladser.";
        }

    }
}

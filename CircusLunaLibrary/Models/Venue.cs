using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Models
{
    public class Venue
    {
        public int StandardSeats { get; set; }
        public int VipSeats { get; set; }
        public List<Seat> AllSeats { get; private set; } = new List<Seat>();
        public string Name { get; set; }

        public Venue(string name, int maxSeats)
        {
            Name = name;
            StandardSeats = maxSeats;
            InitializeSeats();
        }
        public void InitializeSeats()
        {
            int seatsPerRow = 10;
            for (int i = 0; i < VipSeats; i++)
            {
                AllSeats.Add(new Seat('Z',i, SeatType.standard));
            }
                
            for(int i = 0; i < StandardSeats; i++)
            {
                char charRow = (char)('A'+ (i / seatsPerRow)); //TYPE CASTING: computeren ser chars som tal. Derfor A+1=B. (char) er typecasting. Vi caster tallet til en char efter udregningen.
                int seatNumber = (i % seatsPerRow)+1;  //MODULUS: Vi tager det, der er tilbage. 0/10=0+1 -> nr 1. 5/10=5+1 -> nr 6. 27/10=7+1 -> nr 8 osv. Ignorer 10'erne som udgør ROWS.
                if (charRow == 'A' && (i>=0&&i<=9))               
                    AllSeats.Add(new Seat(charRow, seatNumber, SeatType.standard));
                
            }
        }
        public override string ToString()
        {
            return $"Teltet {Name} indeholder {StandardSeats} standardsiddepladser og 10 VIP pladser.";
        }

    }
}

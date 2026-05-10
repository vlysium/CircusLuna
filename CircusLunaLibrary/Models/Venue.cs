using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Models
{
    public class Venue
    {
        public int StandardSeatCount { get; private set; }
        public int VipSeatCount { get; private set; }
        public List<Seat> AllSeats { get; private set; } = new List<Seat>();
        public string Name { get; set; }

        public Venue(string name)
        {
            Name = name;
            StandardSeatCount = 150;
            VipSeatCount = 10;
            InitializeSeats();
        }
        public void InitializeSeats()
        {
            for(int i=1; i <= VipSeatCount; i++)
            {
                AllSeats.Add(new Seat("VIP", i.ToString(), SeatType.VIP));
            }
            for(int i=1; i<=50; i++)
            {
                AllSeats.Add(new Seat("A", i.ToString(), SeatType.standard));
            }
            for(int i=51; i<=100; i++)
            {
                AllSeats.Add(new Seat("B", i.ToString(), SeatType.standard));
            }
            for (int i = 101; i <= 150; i++)
            {
                AllSeats.Add(new Seat("C", i.ToString(), SeatType.standard));
            }
        }
        public override string ToString()
        {
            return $"Teltet {Name} indeholder {StandardSeatCount} standardsiddepladser og {VipSeatCount} VIP pladser.";
        }

    }
}

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

        public Venue(string name, int standardSeatCount, int vipSeatCount)
        {
            Name = name;
            StandardSeatCount = standardSeatCount;
            VipSeatCount = vipSeatCount;
            InitializeSeats();
        }
        public void InitializeSeats()
        {
            AddSeatsToSection("VIP", VipSeatCount, SeatType.VIP);

            int seatCountPerSection = StandardSeatCount / 3;
            AddSeatsToSection("A", seatCountPerSection, SeatType.standard);
            AddSeatsToSection("B", seatCountPerSection, SeatType.standard);
            AddSeatsToSection("C", seatCountPerSection, SeatType.standard);         
           
        }

        public void AddSeatsToSection(string sectionName, int count, SeatType type)
        {
            for(int i = 1; i <= count; i++)
            {
                AllSeats.Add(new Seat(sectionName, i.ToString(), type));
            }
        }
        public override string ToString()
        {
            return $"Teltet {Name} indeholder {StandardSeatCount} standardsiddepladser og {VipSeatCount} VIP pladser.";
        }

    }
}

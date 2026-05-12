using System.Net;

namespace CircusLunaLibrary.Models
{
    public class Customer : Person
    {
        public Customer() : base() { }
        //public List<Reservation> Reservations { get; set; }
        public Customer(string name, string number, string email, Address address)
            : base(name, number, email, address)
        {
        }
        public Customer(string name, string number, string email)
            : base(name, number, email, null)
        {
        }

        public override string ToString()
        {
            return $"Customer - {base.ToString()}";
        }
    }
}
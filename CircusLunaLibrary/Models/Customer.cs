namespace CircusLunaLibrary.Models
{
	public class Customer:Person
	{
		public List<Reservation> Reservations { get; set; }
		public Customer(List<Reservation> reservatons, string name, string number, string email, Address address)
			:base(name, number, email, address)
		{
			Reservations = Reservations;
		}
        public Customer(List<Reservation> reservatons, string name, string number, string email)
            : base(name, number, email, null)
        {            
        }

		public override string ToString()
		{
			return $"{base.ToString()}\nList of reservations:{Reservations.ToString()}";
		}
    }
}

namespace CircusLunaLibrary.Models
{
	public class Customer : Person
	{

		/*
		det her er en properties .
		her opretter jeg en liste af reservationer , da kunden kan have flere resvertioner .
		get= læs , set = ændre . */
		public List<Reservation> Reservations { get; set; }





        /*i min constructor opretter jeg en base som arver fra persons og putter alle værdierne i . 
		Reservations = new List<Reservation>(); = er en tom liste i min constructor  */
        public Customer(string name, string lastName, string email, string phoneNumber)
			: base(name, lastName, email, phoneNumber)
		{
			Reservations = new List<Reservation>();

		}

        public override string ToString()
        {
			return $"PersonId : {PersonId}\n" +
				   $"Name:{Name}\n" +
				   $"Last Name: {LastName}\n" +
				   $"Email: {Email}\n" +
				   $"Phone number : {PhoneNumber}\n" +
				   $"Reservation : {Reservations}";
        }

	}
}

namespace CircusLunaLibrary.Models
{
	public class Person
	{

		/* her er mine properties som jeg sætter og gætter . */
		public string PersonId { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

		/* til min Json ? */
		//public Person() 
		//{
		//}





		/*her opretter jeg min constructor med parameter til for mine properties 
		 jeg laver en GUID = som er et unik kode generator til min personid med 8 cifre som vises . den laver 
		fuld guid cifre på 32. */
		public Person(string name,string lastName, string email, string phoneNumber) 
		{
			PersonId = Guid.NewGuid().ToString().Substring(0, 8);
			Name = name;
			LastName = lastName;
			Email = email;
			PhoneNumber = phoneNumber;
		}





        public override string ToString()
        {
			return $"PersonId : {PersonId}\n" +
				   $"Name:{Name}\n" +
				   $"Last Name: {LastName}\n"+
				   $"Email: {Email}\n" +
				   $"Phone number :{PhoneNumber}\n";

		}
	}
}

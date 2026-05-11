namespace CircusLunaLibrary.Models
{
	public class Employee : Person
	{
		public string PaymentInfo { get; set; }
        public string Role { get; set; }

        public Employee(string name, string lastName, string email, string phoneNumber, string paymentInfo , string role) : base(name, lastName, email, phoneNumber)
		{
			PaymentInfo = paymentInfo;
            Role = role;
		}


        public override string ToString()
        {
            return $"PersonId : {PersonId}\n" +
                   $"Name:{Name}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Email: {Email}\n" +
                   $"Phone number :{PhoneNumber}\n" +
                   $"PaymentInfo : {PaymentInfo}";
        }
	}
}

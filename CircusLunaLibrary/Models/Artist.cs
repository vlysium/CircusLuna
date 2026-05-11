using System.Runtime.CompilerServices;

namespace CircusLunaLibrary.Models
{
	public class Artist : Employee
	{
        
        public bool IsPermenant { get; set; } = true;


        public Artist(string name, string lastName, string email, string phoneNumber, string role, string paymentInfo, bool isPermenant) : base(name, lastName, email, phoneNumber, paymentInfo , role)
		{
			
			IsPermenant = IsPermenant;
		}

        public override string ToString()
        {
            return $"PersonId : {PersonId}\n" +
                   $"Name:{Name}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Email: {Email}\n" +
                   $"Phone number : {PhoneNumber}\n"+
                   $"Artist Role: {Role}\n" +
                   $"Permanent employment: {IsPermenant}\n";
        }
	}
}

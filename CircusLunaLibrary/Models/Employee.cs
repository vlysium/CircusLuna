using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace CircusLunaLibrary.Models
{
	public class Employee:Person
	{
		public string PaymentInfo { get; set; }
        public string Role { get; set; }

        public Employee() : base(){ }
        public Employee(string paymentinfo, string role, string name, string number, string email, Address address)
            : base(name, number, email, address)           
		{
            Role = role;
            PaymentInfo = paymentinfo;
        }
        public Employee(string paymentinfo, string role, string name, string number, string email)
        : this(paymentinfo, role, name, number, email, null)
        {
        }
        public override string ToString()
        {
            
            return  $"{base.ToString()}\nRole: {Role}\nPaymentInfo: {PaymentInfo}";
        }

    }
}

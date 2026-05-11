using System.Net;
using System.Net.Sockets;
using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Customer), typeDiscriminator: "customer")]
    [JsonDerivedType(typeof(Employee), typeDiscriminator: "employee")]
    [JsonDerivedType(typeof(Artist), typeDiscriminator: "artist")]
    public abstract class Person
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public string Number { get; set; }
		public Address? Address { get; set; }
		public string Email { get; set; }

		public Person()
		{
			ID = Guid.NewGuid().ToString().Substring(0,8);
		}
		public Person(string name, string number, string email) 
			: this()
		{
            Name = name;
            Number = number;
            Email = email;            
        }
		public Person(string name, string number, string email, Address address)
			:this(name, number, email)
		{
            Address = address;
        }

		public override string ToString()
		{
			return $"ID: {ID}. \nNavn: {Name}. \nNummer: {Number}. \nAddresse: {Address}. \nEmail: {Email}";
		}
	}
}

using CircusLunaLibrary.Models.CircusLunaLibrary.Models;
using System.Net;

namespace CircusLunaLibrary.Models
{
    public class Artist : Employee
    {
        public bool IsPermanent { get; set; }
        public Artist(string paymentinfo, string role, bool isPermanent, string name, string number, string email, Address address)
            : base(paymentinfo, role, name, number, email, address)
        {
            IsPermanent = isPermanent;
        }
        public Artist(string paymentinfo, string role, bool isPermanent, string name, string number, string email)
        : base(paymentinfo, role, name, number, email, null)
        {
            IsPermanent = isPermanent;
        }
        public override string ToString()
        {
            return $"{base.ToString()}\nPermanent:{IsPermanent}";

        }
    }
}
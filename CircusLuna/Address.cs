using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Models
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public Address()
        {
        }
        public Address(string addressLine1, string addressLine2, string postalCode, string city)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            PostalCode = postalCode;
            City = city;
        }
        public override string ToString()
        {
            string secondLine = string.IsNullOrWhiteSpace(AddressLine2) ? "" : $"{AddressLine2}\n";
            return $"{AddressLine1} {secondLine}{PostalCode} {City}";
        }
    }
}
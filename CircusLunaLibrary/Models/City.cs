using System.Text.Json.Serialization;

namespace CircusLunaLibrary.Models
{
    public class City
    {
        public string CityID { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public Region? Region { get; set; }

        [JsonConstructor]
        public City()
        {
            CityID = Guid.NewGuid().ToString().Substring(0, 8);
        }
        public City(string name, string postalCode) : this()
        {            
            Name = name;
            PostalCode = postalCode;
            
        }
        public City(string name, string postalCode, Region region):this(name, postalCode)
        {            
            Region = region;
        }
        public override string ToString()
        {
            return $"{Name} {PostalCode} {Region}";
        }
    }
}
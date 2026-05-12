namespace CircusLunaLibrary.Models
{
    public class City
    {
        public string CityID { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public Region Region { get; set; }
        public City(string name, string postalCode, Region region)
        {
            CityID = Guid.NewGuid().ToString().Substring(0, 8);
            Name = name;
            PostalCode = postalCode;
            Region = region;
        }
        public override string ToString()
        {
            return $"{Name} {PostalCode} {Region}";
        }
    }
}
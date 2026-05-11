namespace CircusLunaLibrary.Models
{
	public class City
	{
		public string CityId { get; set; } 
		public string CityName { get; set; }
		public int PostCode { get; set; }
		Region Region { get; set; }


        /* det skal laves en tom constructor til vores Jfile.*/
        //public Adresse() 
        //{
        //}





        /*Her er min constructor .
		jeg laver en public constructor som er tilgægelig for alle mine andre classer .
		(string cityName, int postCode, Region region) = jeg skriver mine parameter ind 
		jeg bruger CityID = GUID som er et unik kode som typisk er på 32 cifre , men ved hjælp af Substring(0,2)
		vil indexen starte fra 0 og 2 frem og ved ToString(). konverter jeg det til string, den vil kun vise de 
		første 2 af hele guid id. . */
        public City(string cityName, int postCode, Region region) 
		{
			CityId = Guid.NewGuid().ToString().Substring(0,4);
			CityName = cityName;
			PostCode = postCode;
			Region = region;
		}




		/* min ToString override konverter alt hvad jeg har i klassen til en læses teks , uden dette vil den 
		 * kune returner namespaces navn , med en override overskriver jeg metoden. . */
		public override string ToString() 
		{
			return $"CityId: {CityId}\n" +
				   $"City Name: {CityName}\n" +
				   $"Postcode: {PostCode}\n" +
				   $"Region: {Region}\n";
		}

	}

}

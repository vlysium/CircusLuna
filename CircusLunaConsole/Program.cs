using CircusLunaLibrary.Models;

Address A1Address = new Address("vejen", "35B", "4700", "Naestved");
Artist A1 = new Artist("IBANdfjhdj", "clown", true, "Patrik Hansen", "22222222", "patrik@circusluna.dk", A1Address);
Console.WriteLine(A1.ToString());

Employee E1 = new Employee("IBAN3264234", "amdin", "Lars Petersen", "55555555", "Lars@cirkusluna.dk");
Console.WriteLine(E1.ToString());

//Venue TeltA = new Venue("TeltA", 150, 10);
//List<Seat> allSeats = TeltA.AllSeats;
//foreach (Seat s in allSeats) { Console.WriteLine(s.ToString()); }

DateTime post1Date = DateTime.Now;
BlogPost post1 = new BlogPost("Cirkus Luna kommer til Ringsted!", "Cirkus Luna er vokset og kan nu besøge flere byer, herunder Ringsted! Skynd jer at booke billetter og glæd jer til fantastisk børnevenlig underholdning for hele familien", post1Date);
Console.WriteLine(post1.ToString());


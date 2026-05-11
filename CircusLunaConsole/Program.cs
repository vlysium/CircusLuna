using CircusLunaLibrary.Models;

Address A1Address = new Address("vejen", "35B", "4700", "Naestved");
Artist A1 = new Artist("IBANdfjhdj", "clown", true, "Patrik Hansen", "22222222", "patrik@circusluna.dk", A1Address);
Console.WriteLine(A1.ToString());

Employee E1 = new Employee("IBAN3264234", "amdin", "Lars Petersen", "55555555", "Lars@cirkusluna.dk");
Console.WriteLine(E1.ToString());

Person employee1 = new Employee("IBAN3243", "Admin", "Henrik Larsen", "88888888", "Henrik@cirkusluna.dk");
Person customer1 = new Customer("Fie Pedersen", "44444444", "fie@hotmail.com");
Person artist1 = new Artist("IBAN33434", "clown", true, "Jens", "12453562", "jens@gmail.com");

Console.WriteLine("__________________________________________________________________");
List<Person> people = new List<Person>();
people.Add(employee1);
people.Add(customer1);
people.Add(artist1);
people.Add(A1);
people.Add(E1);
foreach(Person p in people)
{
    Console.WriteLine(p.ToString());
}
Console.WriteLine("_________________________________________________________________");

List<Person> employees = new List<Person>();
foreach (Person p in people)
{
    if (p is Employee)
    {
        employees.Add(p);
    }
}

foreach(Employee e in employees)
{
    Console.WriteLine(e.ToString());
}




//Venue TeltA = new Venue("TeltA", 150, 10);
//List<Seat> allSeats = TeltA.AllSeats;
//foreach (Seat s in allSeats) { Console.WriteLine(s.ToString()); }

DateTime post1Date = DateTime.Now;
BlogPost post1 = new BlogPost("Cirkus Luna kommer til Ringsted!", "Cirkus Luna er vokset og kan nu besøge flere byer, herunder Ringsted! Skynd jer at booke billetter og glæd jer til fantastisk børnevenlig underholdning for hele familien", post1Date);
Console.WriteLine(post1.ToString());


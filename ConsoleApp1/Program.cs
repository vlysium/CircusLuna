using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System.ComponentModel;

namespace CircusConsol
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /// test
            /// 

            /*opretter byer */
            City city = new City("Roskilde",4000,Region.Sjealland);
     
            Person person1 = new Person("Saif","Atyaif" ,"Saifatyaif@gmail.com", "52177690");

            Seat seat = new Seat("3a ", SeatType.Vip);

            Artist artist = new Artist("Henrik", "Larsen ", "HenrikLarsen@gmail.com", "54555544", "Klovn", "Reg: 7080 Konto: 48887744556", true);

            Employee employee = new Employee("Ali", "Madie", "AliMadie@gmail.com", "58877744", "Reg: 7080 Konto: 48887744556" , "Klovn");

            Customer customer = new Customer("Saif ", "Atyaif ", "saifatyaif@gmail.com", "52177690");
            Reservation reservation = new Reservation();
            Ticket ticket = new Ticket(TicketType.VIP);
            Ticket Ticketype = new Ticket(TicketType.VIP);
            reservation.AddTicket(Ticketype);

            DateTime datetime = new DateTime();

            Performance performance = new Performance(datetime,city,seat,artist);
           // Console.WriteLine(customer);
            Console.WriteLine($"Customer information: \n{customer}");
            Console.WriteLine("");
            Console.WriteLine($"Ticket Information : \n {ticket}");
            Console.WriteLine("");
            Console.WriteLine($"Performance information : \n {performance}");
            Console.WriteLine("");
            Console.WriteLine($"Reservations information : \n {reservation}");
            Console.WriteLine("");
            Console.WriteLine($"Seat information : \n {seat}");
            Console.ReadLine();
        }
    }
}

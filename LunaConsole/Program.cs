using CircusLunaLibrary.Models;
namespace LunaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Venue venue = new Venue("RC", 10, 12);
            foreach(Seat s in venue.Seats)
            {
                Console.WriteLine(s);
            }
        }
    }
}

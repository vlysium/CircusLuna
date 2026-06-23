using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using CircusLunaLibrary.Services;
using System.Collections.Concurrent;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;
namespace LunaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PersonRepository repo = new PersonRepository();
            List<Person> people = repo.GetAll();




































            //Vi laver et produkt katalog som dictionary. Lynhurtige opslag!
            Item product1 = new Item("This Shampoo is great", "BestShampoo");
            Item product2 = new Item("A conditioner that leaves your hair smooth like silk", "BestConditioner");
            Item product3 = new Item("This Lotion is great", "BestLotion");
            Item product4 = new Item("This Handcreme is great", "BestHandcreme");
            Item product5 = new Item("Beautiful luxery bag", "Chanel");
            Item product6 = new Item("Toiletbrush", "CleanUpNow");
            Item product7 = new Item("Sunscreen", "Avene");

            Dictionary<int, Item> productCatalogue = new Dictionary<int, Item>();
            productCatalogue.Add(product1.ID, product1);
            productCatalogue.Add(product2.ID, product2);
            productCatalogue.Add(product3.ID, product3);
            productCatalogue.Add(product4.ID, product4);
            productCatalogue.Add(product5.ID, product5);
            productCatalogue.Add(product6.ID, product6);
            productCatalogue.Add(product7.ID, product7);

            //varer i kurven gemmes som IDs. 
            List<int> CartItemsById = new List<int>();
            CartItemsById.Add(1);
            CartItemsById.Add(3);
            CartItemsById.Add(5);
            CartItemsById.Add(6);
            
            //nu bruges ID til at filtrere i dictionary og få en liste af udvalgte produkter. 
            List<Item> CartItems = new List<Item>();
            foreach(int i in CartItemsById)
            {
                if (productCatalogue.ContainsKey(i))
                {
                    CartItems.Add(productCatalogue[i]);
                }
            }
            //hvis vi har en liste over kundeIDer fra VIPS.
            //og en kæmpe liste med transaktioner, hvori der bla er gemt kundeIDer. 
            //vi behandler VIP transaktioner først -> filtrer den rå datalise med transaktioner vha dictionary med VIP kunderIDer.



        }
    }
}



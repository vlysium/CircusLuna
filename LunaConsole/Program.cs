using CircusLunaLibrary.Models;
namespace LunaConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Employee("dfsf", "clown", "Linda", "123456", "mail.dk");
            Person p2 = new Artist("sdfd", "strongMan", true, "mads", "6784364", "mads.dk");
            Person p3 = new Employee("IBAN343", "linedancer", "Camilla", "5678907", "nmkl");
            Person p4 = new Employee("rwjdsk", "dsjf", "Linds", "5647i", "dsjk");

            List<Person> sortedAlphabetically = new List<Person>();
            List<Person> allPeople = new List<Person>
            {
                p1,
                p2,
                p3,
                p4
            };


            int counter = 0;            
            while (counter < allPeople.Count)
            {
                int iterations = allPeople.Count - counter;
                for (int i = 0; i < iterations-1; i++)
                {
                    char[] person0 = allPeople[i].Name.ToLower().ToCharArray();
                    char[] person1 = allPeople[i + 1].Name.ToLower().ToCharArray();

                    int shortestArray = 0;
                    if (person0.Length < person1.Length)
                    {
                        shortestArray = person0.Length;
                    }
                    else
                    {
                        shortestArray = person1.Length;
                    }
                    //int shortestArray = Math.Min(person0.Length, person1.Length);

                    for (int j=0; j<shortestArray; j++)
                    {
                        if ((person0[j] < person1[j]))
                        {
                            break; // Already in the right order, break the loop
                        }
                        else if (person1[j] < person0[j])
                        {
                            Person person = allPeople[i];
                            allPeople[i] = allPeople[i + 1];
                            allPeople[i + 1] = person;
                            break;
                        }

                    }                   
                }
                counter++;
            }

            foreach(Person p in allPeople)
            {
                Console.WriteLine(p);
            }


            //if (person1[0] < person0[0] || (person1[0] == person0[0] && person1[1] < person0[1]))
            //{
            //    Person person = allPeople[i];
            //    allPeople[i] = allPeople[i + 1];
            //    allPeople[i + 1] = person;
            //}

        }
    }
}

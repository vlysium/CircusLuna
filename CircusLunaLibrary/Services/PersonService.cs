using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;

namespace CircusLunaLibrary.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void CreatePerson(Person person)
        {
            _personRepository.CreatePerson(person);
        }
        public void DeletePerson(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty", nameof(id));
            }
            _personRepository.DeletePerson(id);

        }
        public Person GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return _personRepository.GetById(id);
        }
        public List<Artist> GetAllArtists()
        {
            List<Person> AllPeople=_personRepository.GetAll();
            List<Artist> AllArtists= new List<Artist>();
            foreach(Person p in AllPeople)
            {
                if (p is Artist)
                {
                    AllArtists.Add((Artist)p);
                }
            }
            return AllArtists;
        }
        public List<Person> GetAll()
        {
            return _personRepository.GetAll();
        }
       
        public void UpdateEmployee(string id, Employee employee)
        {
            _personRepository.UpdatePerson(id, employee);
        }
        public List<Person> SortByNameAZ()
        {
            List<Person> allPeople = new List<Person>();
            int counter = 0;
            while (counter < allPeople.Count)
            {
                int iterations = allPeople.Count - counter;
                for (int i = 0; i < iterations - 1; i++)
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

                    for (int j = 0; j < shortestArray; j++)
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
            return allPeople;
        }
    }
}

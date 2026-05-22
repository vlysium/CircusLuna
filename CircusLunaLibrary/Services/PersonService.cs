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
        public List<Person> SortByNameAZ(List<Person> allPeople, bool AZ)
        {
            List<Person> people = allPeople;
            int counter = 0;
            while (counter < people.Count)
            {
                int iterations = people.Count - counter;
                for (int i = 0; i < iterations - 1; i++)
                {    
                    string person0 = people[i].Name.ToLower();
                    string person1 = people[i + 1].Name.ToLower();
                                        
                    if (person0.Length > person1.Length && person0.StartsWith(person1))
                    {
                        Person person = people[i];
                        people[i] = people[i + 1];
                        people[i + 1] = person;
                    }
                    else
                    {                        
                        int shortestString = Math.Min(person0.Length, person1.Length);

                        for (int j = 0; j < shortestString; j++)
                        {
                            if ((person0[j] < person1[j]))
                            {
                                break; // Already in the right order, break the loop
                            }
                            else if (person1[j] < person0[j])
                            {
                                Person person = people[i];
                                people[i] = people[i + 1];
                                people[i + 1] = person;
                                break;
                            }
                        }
                    }                   
                }
                counter++;
            }
            if (!AZ)
            {
                people.Reverse();
                return people;
            }
            return people;
            //Udregne shortestString uden Math.Min: 
            //int shortestString = 0;
            //if person0.Length < person1.Length){shortestString = person0.Length;}
            //else{shortestString = person1.Length;}
        }
    }
}

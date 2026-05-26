using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System.Globalization;

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

        public void UpdateEmployee(string id, Employee employee)
        {
            _personRepository.UpdatePerson(id, employee);
        }
        public Person GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return _personRepository.GetById(id);
        }

        public List<Person> GetAll()
        {
            List<Person> People = new List<Person>();
            People = _personRepository.GetAll();
            return People;
        }


        public List<Artist> GetAllArtists()
        {
            List<Person> AllPeople = GetAll();
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
        public List<Artist> SelectedArtistsStringToArtist(List<string>SelectedArtistIds)
        {
            List<Artist> allArtists = GetAllArtists();
            List<Artist> SelectedArtists = new List<Artist>();

            if (SelectedArtistIds == null)
            {
                SelectedArtistIds = new List<string>();
            }

            // Cross-reference the posted IDs against the master artist list to rebuild the list object
            foreach (Artist a in allArtists)
            {
                if (SelectedArtistIds.Contains(a.ID))
                {
                    SelectedArtists.Add(a);
                }
            }
            return SelectedArtists;
        }
     

        public List<Person> FilterAndSearch(string SearchTerm)
        {
            List<Person> People = GetAll();
            if (!string.IsNullOrWhiteSpace(SearchTerm))  
            {
                List<Person> SearchTermList = new List<Person>();
                string searchTermClean = SearchTerm.Trim().ToLower();
                foreach (Employee e in People)
                {
                    bool nameMatches = e.Name != null && e.Name.ToLower().Contains(searchTermClean);
                    bool numberMatches = e.Number != null && e.Number.Contains(searchTermClean);
                    bool roleMatches = e.Role != null && e.Role.ToLower().Contains(searchTermClean);
                    bool permanentMatches = false;
                    if(e is Artist a)
                    {
                        if (a.IsPermanent&&searchTermClean=="permanent") { permanentMatches=true; }                        
                    }

                    if (nameMatches || numberMatches || roleMatches||permanentMatches)
                    {
                        SearchTermList.Add(e);
                    }
                }
                People = SearchTermList;
            }
            return People;
        }


        public List<Person> SortByNameAZ(List<Person> allPeople, string SortBy)
        {
            bool AZ = true;
            List<Person> people = allPeople;

            switch (SortBy)
            {
                case "sortByNameZA":
                    AZ = false;
                    break;
                case "sortByNameAZ":
                    AZ = true;
                    break;
                default:
                    AZ = true;
                    break;
            }
            
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

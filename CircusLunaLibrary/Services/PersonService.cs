using CircusLunaLibrary.Models;
using CircusLunaLibrary.Repositories;
using System.Globalization;

namespace CircusLunaLibrary.Services
{
    /// <summary>
    /// Service layer responsible for executing domain logic surrounding people operations.
    /// Handles filtering, sorting using a custom bubble sort implementation, and structural cross-referencing for staff and performers.
    /// </summary>
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        /// <param name="personRepository">The data repository interface used to persist and retrieve person records.</param>
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        /// <summary>
        /// Adds a new profile entity in the underlying database system.
        /// </summary>
        /// <param name="person">The data model instance containing the target information to write.</param>
        public void AddPerson(Person person)
        {
            _personRepository.AddPerson(person);
        }

        /// <summary>
        /// Deletes a personnel record permanently from storage.
        /// </summary>
        /// <param name="id">The unique lookup identity token of the target entity.</param>
        /// <exception cref="ArgumentException">Thrown when the provided lookup key is empty or whitespace characters.</exception>
        public void DeletePerson(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("ID cannot be null or empty", nameof(id));
            }
            _personRepository.DeletePerson(id);
        }

        /// <summary>
        /// Dispatches data modifications to overwrite field values on an existing record.
        /// </summary>
        /// <param name="id">The original stable identity token of the target system record.</param>
        /// <param name="employee">The domain container tracking the modern properties to persist.</param>
        public void UpdateEmployee(string id, Employee employee)
        {
            _personRepository.UpdatePerson(id, employee);
        }

        /// <summary>
        /// Locates a specific structural base entity object matched against an identity string.
        /// </summary>
        /// <param name="id">The tracking lookup reference sequence.</param>
        /// <returns>The localized polymorphic <see cref="Person"/> instance if found; otherwise, returns <see langword="null"/>.</returns>
        public Person GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return _personRepository.GetById(id);
        }

        /// <summary>
        /// Compiles a global roster tracking list containing every person record found in storage.
        /// </summary>
        /// <returns>A data <see cref="List{Person}"/> of system personnel profiles.</returns>
        public List<Person> GetAll()
        {
            List<Person> People = new List<Person>();
            People = _personRepository.GetAll();
            return People;
        }

        /// <summary>
        /// Extracts and filters out only independent performer entities from the global people profile collection.
        /// </summary>
        /// <returns>A narrow tracking collection containing only verified <see cref="Artist"/> entity structures.</returns>
        public List<Artist> GetAllArtists()
        {
            List<Person> AllPeople = GetAll();
            List<Artist> AllArtists = new List<Artist>();
            foreach (Person p in AllPeople)
            {
                if (p is Artist)
                {
                    AllArtists.Add((Artist)p);
                }
            }
            return AllArtists;
        }

        /// <summary>
        /// Evaluates a collection of flat identity keys against the master runtime registry 
        /// to reconstruct a unified collection of structural artist domain entities.
        /// </summary>
        /// <param name="SelectedArtistIds">The collection of flat identifier lookup strings assigned to selected artists.</param>
        /// <returns>A fully materialized collection containing verified <see cref="Artist"/> objects.</returns>
        public List<Artist> SelectedArtistsStringToArtist(List<string> SelectedArtistIds)
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

        /// <summary>
        /// Filters personnel list metrics using multi-field text matching across identities, labels, roles, and status flags.
        /// </summary>
        /// <param name="searchFilterWord">The string text variable deployed to isolate target rows.</param>
        /// <returns>A filtered dataset containing matching records.</returns>
        public List<Person> FilterAndSearch(string searchFilterWord)
        {
            List<Person> people = GetAll();
            if (!string.IsNullOrWhiteSpace(searchFilterWord))
            {
                List<Person> searchFilterList = new List<Person>();
                string searchFilterWordClean = searchFilterWord.Trim().ToLower();
                foreach (Employee e in people)
                {
                    bool nameMatches = e.Name != null && e.Name.ToLower().Contains(searchFilterWordClean);
                    bool numberMatches = e.Number != null && e.Number.Contains(searchFilterWordClean);
                    bool roleMatches = e.Role != null && e.Role.ToLower().Contains(searchFilterWordClean);
                    bool permanentMatches = false;

                    if (e is Artist a)
                    {
                        if (a.IsPermanent && searchFilterWordClean == "permanent") { permanentMatches = true; }
                    }

                    if (nameMatches || numberMatches || roleMatches || permanentMatches)
                    {
                        searchFilterList.Add(e);
                    }
                }
                people = searchFilterList;
            }
            return people;
        }

        /// <summary>
        /// Alphabetizes a collection of tracking personnel data models by Name using a custom iterative bubble sort implementation.
        /// </summary>
        /// <param name="allPeople">The collection data to sort in place.</param>
        /// <param name="SortBy">The targeted command selector string guiding alpha directionality flags (e.g., 'sortByNameZA').</param>
        /// <returns>The alphabetized collection mapping.</returns>
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
        }
    }
}
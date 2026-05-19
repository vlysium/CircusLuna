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
        public void UpdateArtist(string id, Artist artist)
        {
            //Artist artistFromData = (Artist)GetById(id);
            //artistFromData.Name = artist.Name;
            //artistFromData.PaymentInfo = artist.PaymentInfo;
            //artistFromData.Number = artist.Number;
            //artistFromData.Role = artist.Role;
            //artistFromData.IsPermanent = artist.IsPermanent;
            _personRepository.UpdatePerson(id, artist);           

        }
        public void UpdateEmployee(string id, Employee employee)
        {
            _personRepository.UpdatePerson(id, employee);
        }
    }
}

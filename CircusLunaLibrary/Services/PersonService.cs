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

	}
}

using CircusLunaLibrary.Models;
using System.Text.Json;

namespace CircusLunaLibrary.Repositories
{
	public class PersonRepository : IPersonRepository
	{
        private readonly string _filePath = Path.Combine("Data", "Person.json");        
        private List<Person> People = new List<Person>();
        public PersonRepository()
        {
            if (File.Exists(_filePath))
            {
                LoadFile();
            }            
        }
        public void LoadFile()
        {
            if (!File.Exists(_filePath))
            {
                People = new List<Person>();
                return;
            }
            string json = File.ReadAllText(_filePath);
            People = JsonSerializer.Deserialize<List<Person>>(json) ?? new List<Person>();
        }
        public void SaveFile()
        {            
            string json = JsonSerializer.Serialize<List<Person>>(People);
            File.WriteAllText(_filePath, json);
        }
        public void CreatePerson(Person person)
        {            
            People.Add(person);
            SaveFile();
        }
        public void DeletePerson(string id)        
        {
            Person person = GetById(id);
            if (person != null)
            {
                People.Remove(person);
                SaveFile();
            }
        }

        public Person GetById(string id)        {
           
            foreach(Person p in People)
            {
                if (p.ID == id)
                {
                    return p;
                }
            }
            return null;
        }

        public void CreatePerson()
        {
            throw new NotImplementedException();
        }

        public void GetByid(string id)
        {
            throw new NotImplementedException();
        }
    }
}

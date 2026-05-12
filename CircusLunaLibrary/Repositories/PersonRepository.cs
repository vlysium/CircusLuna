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
        public List<Person> GetAll()
        {
            LoadFile();
            return People;
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
        public void UpdatePerson(string id, Person updatedPerson)
        {
            LoadFile();
            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].ID == id)
                {
                    People[i] = updatedPerson;
                }
            }
        }
        public Person GetById(string id)
        {

            foreach (Person p in People)
            {
                if (p.ID == id)
                {
                    return p;
                }
            }
            return null;
        }        
    }
    }
using CircusLunaLibrary.Models;
using System.Text.Json;
using System.IO;

namespace CircusLunaLibrary.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly string _filePath = Path.Combine("Data", "people.json");
        private List<Person> People = new List<Person>();
        public PersonRepository()
        {
            LoadFile();
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
            string json = JsonSerializer.Serialize<List<Person>>(People, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
        public List<Person> GetAll()
        {
            LoadFile();
            return People;
        }
        public void AddPerson(Person person)
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
                    break;
                }
            }
            SaveFile();
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
using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Repositories
{
    public interface IPersonRepository
    {
        public void LoadFile();
        public void SaveFile();
        public List<Person> GetAll();
        public void CreatePerson(Person person);        
        public void DeletePerson(string id);
        public void UpdatePerson(string id, Person updatedPerson);
        public Person GetById(string id);


    }
}
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
        public void CreatePerson(Person person);
        public Person GetById(string id);
        public void DeletePerson(string id);


    }
}
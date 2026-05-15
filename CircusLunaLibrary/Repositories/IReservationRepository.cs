using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Repositories
{
    public interface IReservationRepository
    {
        public void SaveFile();
        public void LoadFile();
        public List<Reservation> GetAll();
        public Reservation GetByID(string id);
        public void AddReservation(Reservation reservation);
        public void DeleteReservation(string id);
        public void UpdateReservation(string id, Reservation reservation);

    }
}

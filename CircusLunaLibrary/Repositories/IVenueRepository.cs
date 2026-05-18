using CircusLunaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CircusLunaLibrary.Repositories
{
    public interface IVenueRepository
    {
        public void SaveFile();
        public void LoadFile();
        public void EditVenue(Venue venue);
        public Venue GetVenue();
    }
}

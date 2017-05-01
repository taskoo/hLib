using hLib.Models;
using System;
using System.Collections.Generic;

namespace hLib.DAL.IRepositories
{
    public interface INationalityRepository : IDisposable
    {
        IEnumerable<Nationality> GetNationalitys();
        Nationality GetNationalityByID(int nationalityId);
        void InsertNationality(Nationality nationality);
        void DeleteNationality(int nationalityId);
        void UpdateNationality(Nationality nationality);
        void Save();

    }
}

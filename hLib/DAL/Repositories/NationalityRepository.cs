using hLib.DAL.IRepositories;
using hLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace hLib.DAL.Repositories
{
    public class NationalityRepository : INationalityRepository, IDisposable
    {
        private HLibDBContext context;

        public NationalityRepository(HLibDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Nationality> GetNationalitys()
        {
            return context.Nationalities.ToList();
        }

        public Nationality GetNationalityByID(int id)
        {
            return context.Nationalities.Find(id);
        }

        public void InsertNationality(Nationality nationality)
        {
            context.Nationalities.Add(nationality);
        }

        public void DeleteNationality(int nationalityId)
        {
            Nationality nationality = context.Nationalities.Find(nationalityId);
            context.Nationalities.Remove(nationality);
        }

        public void UpdateNationality(Nationality nationality)
        {
            context.Entry(nationality).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
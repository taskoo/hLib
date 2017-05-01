using hLib.DAL.IRepositories;
using hLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace hLib.DAL.Repositories
{
    public class LanguageRepository : ILanguageRepository, IDisposable
    {
        private HLibDBContext context;

        public LanguageRepository(HLibDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return context.Languages.ToList();
        }

        public Language GetLanguageByID(int languageId)
        {
            return context.Languages.Find(languageId);
        }

        public void InsertLanguage(Language language)
        {
            context.Languages.Add(language);
        }

        public void DeleteLanguage(int languageId)
        {
            Language language = context.Languages.Find(languageId);
            context.Languages.Remove(language);
        }

        public void UpdateLanguage(Language language)
        {
            context.Entry(language).State = EntityState.Modified;
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
using hLib.Models;
using System;
using System.Collections.Generic;

namespace hLib.DAL.IRepositories
{
    public interface ILanguageRepository : IDisposable
    {
        IEnumerable<Language> GetLanguages();
        Language GetLanguageByID(int languageId);
        void InsertLanguage(Language language);
        void DeleteLanguage(int languageId);
        void UpdateLanguage(Language language);
        void Save();

    }
}


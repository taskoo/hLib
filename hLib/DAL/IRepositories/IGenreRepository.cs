using hLib.Models;
using System;
using System.Collections.Generic;

namespace hLib.DAL.IRepositories
{
    public interface IGenreRepository : IDisposable
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenreByID(int genreId);
        void InsertGenre(Genre genre);
        void DeleteGenre(int genreId);
        void UpdateGenre(Genre genre);
        void Save();

    }
}


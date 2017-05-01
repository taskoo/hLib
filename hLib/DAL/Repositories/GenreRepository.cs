using hLib.DAL.IRepositories;
using hLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace hLib.DAL.Repositories
{
    public class GenreRepository : IGenreRepository, IDisposable
    {
        private HLibDBContext context;

        public GenreRepository(HLibDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return context.Genres.ToList();
        }

        public Genre GetGenreByID(int genreId)
        {
            return context.Genres.Find(genreId);
        }

        public void InsertGenre(Genre genre)
        {
            context.Genres.Add(genre);
        }

        public void DeleteGenre(int genreId)
        {
            Genre genre = context.Genres.Find(genreId);
            context.Genres.Remove(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            context.Entry(genre).State = EntityState.Modified;
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
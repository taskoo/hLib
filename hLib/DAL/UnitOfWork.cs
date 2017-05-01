using hLib.DAL.IRepositories;
using hLib.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hLib.DAL
{
    public class UnitOfWork : IDisposable
    {
        private HLibDBContext _context;

        public UnitOfWork(HLibDBContext context)
        {
            _context = context;
            BooksRP = new BookRepository(_context);
            AuthorsRP = new AuthorRepository(_context);
            NationalitiesRP = new NationalityRepository(_context);
            LanguagesRP = new LanguageRepository(_context);
            GenresRP = new GenreRepository(_context);
        }

        public IBookRepository BooksRP { get; private set; }
        public IAuthorRepository AuthorsRP { get; private set; }
        public IGenreRepository GenresRP { get; private set; }
        public ILanguageRepository LanguagesRP { get; private set; }
        public INationalityRepository NationalitiesRP { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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

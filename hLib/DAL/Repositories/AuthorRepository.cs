using hLib.DAL.IRepositories;
using hLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace hLib.DAL.Repositories
{
    public class AuthorRepository : IAuthorRepository, IDisposable
    {
        private HLibDBContext context;

        public AuthorRepository(HLibDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        public Author GetAuthorByID(int authorId)
        {
            return context.Authors.Find(authorId);
        }

        public void InsertAuthor(Author author)
        {
            context.Authors.Add(author);
        }

        public void DeleteAuthor(int authorId)
        {
            Author author = context.Authors.Find(authorId);
            context.Authors.Remove(author);
        }

        public void UpdateAuthor(Author author)
        {
            context.Entry(author).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
       
        public Author GetAuthorWithBooks(int id)
        {
            return context.Authors.Include(c => c.Books).Where(i => i.AuthorId == id).Single();
        }

        public IEnumerable<Author> GetData(out int totalRecords, string globalSearch, string orderBy, bool desc, int? limitOffset, int? limitRowCount)
        {

            var query = GetAuthors().ToList().AsQueryable();

            totalRecords = query.Count();

            if (!String.IsNullOrWhiteSpace(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "authorfirstname":
                        if (!desc)
                            query = query.OrderBy(p => p.AuthorFirstName);
                        else
                            query = query.OrderByDescending(p => p.AuthorFirstName);
                        break;
                    case "authorlastname":
                        if (!desc)
                            query = query.OrderBy(p => p.AuthorLastName);
                        else
                            query = query.OrderByDescending(p => p.AuthorLastName);
                        break;
                    case "authormiddlename":
                        if (!desc)
                            query = query.OrderBy(p => p.AuthorMiddleName);
                        else
                            query = query.OrderByDescending(p => p.AuthorMiddleName);
                        break;
                    case "nationality":
                        if (!desc)
                            query = query.OrderBy(p => p.Nationality);
                        else
                            query = query.OrderByDescending(p => p.Nationality);
                        break;
                }
            }

            if (!String.IsNullOrWhiteSpace(globalSearch) && globalSearch != null)
            {
                query = query.Where(p => (p.AuthorFirstName + " " + p.AuthorMiddleName + " " + p.AuthorLastName).ToLower().Contains(globalSearch.ToLower()));
            }


            if (limitOffset.HasValue)
            {
                query = query.Skip(limitOffset.Value).Take(limitRowCount.Value);
            }

            return query.ToList();
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
using hLib.DAL.IRepositories;
using hLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace hLib.DAL.Repositories
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private HLibDBContext context;

        public BookRepository(HLibDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Book> GetBooks()
        {
            var query = context.Books.ToList().AsQueryable();
            return query.ToList();
        }

        public Book GetBookByID(int id)
        {
            return context.Books.Find(id);
        }

        public void InsertBook(Book book)
        {
            context.Books.Add(book);
        }

        public void DeleteBook(int bookId)
        {
            Book book = context.Books.Find(bookId);
            context.Books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }       

        public Book GetBookWithAuthors(int id)
        {
            return context.Books.Include(c => c.Authors).Where(i => i.BookId == id).Single();
        }

        public IEnumerable<Book> GetData(out int totalRecords, string globalSearch, string orderBy, bool desc, int? limitOffset, int? limitRowCount)
        {

            var query = GetBooks().ToList().AsQueryable();

            if (!String.IsNullOrWhiteSpace(globalSearch) && globalSearch != null)
            {
                query = query.Where(p => p.Title.ToLower().Contains(globalSearch.ToLower()));
            }

            totalRecords = query.Count();

            if (!String.IsNullOrWhiteSpace(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case "title":
                        if (!desc)
                            query = query.OrderBy(p => p.Title);
                        else
                            query = query.OrderByDescending(p => p.Title);
                        break;
                    case "id":
                        if (!desc)
                            query = query.OrderBy(p => p.BookId);
                        else
                            query = query.OrderByDescending(p => p.BookId);
                        break;
                }
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
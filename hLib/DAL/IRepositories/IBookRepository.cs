using hLib.Models;
using System;
using System.Collections.Generic;

namespace hLib.DAL.IRepositories
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookByID(int bookId);
        void InsertBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book);
        void Save();
        Book GetBookWithAuthors(int id);
        IEnumerable<Book> GetData(out int totalRecords, string globalSearch, string orderBy, bool desc, int? limitOffset, int? limitRowCount);
    }
}


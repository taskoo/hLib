using hLib.Models;
using System;
using System.Collections.Generic;

namespace hLib.DAL.IRepositories
{
    public interface IAuthorRepository : IDisposable
    {
        IEnumerable<Author> GetAuthors();
        Author GetAuthorByID(int authorId);
        void InsertAuthor(Author author);
        void DeleteAuthor(int authorId);
        void UpdateAuthor(Author author);
        void Save();
        Author GetAuthorWithBooks(int id);
        IEnumerable<Author> GetData(out int totalRecords, string globalSearch, string orderBy, bool desc, int? limitOffset, int? limitRowCount);
    }
}


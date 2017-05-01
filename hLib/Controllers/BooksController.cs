using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hLib.Models;
using hLib.DAL;
using hLib.Models.ViewModels;

namespace hLib.Controllers
{
    public class BooksController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DAL.HLibDBContext());

        //private IBookRepository unitOfWork.BooksRP;

        //public BooksController()
        //{
        //    this.unitOfWork.BooksRP = new BookRepository(new HolyContext());
        //}

        //public BooksController(IBookRepository unitOfWork.BooksRP)
        //{
        //    this.unitOfWork.BooksRP = unitOfWork.BooksRP;
        //}

        // GET: Books
        public ActionResult Index(/*string sortOrder*/)
        {
            var books = unitOfWork.BooksRP.GetBooks();

            ViewBag.currentPage = "books";

            ViewBag.GenreId = new SelectList(unitOfWork.GenresRP.GetGenres(), "GenreId", "GenreName");
            ViewBag.LanguageId = new SelectList(unitOfWork.LanguagesRP.GetLanguages(), "LanguageId", "LanguageName");

            //ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "Title desc" : "";
            //ViewBag.TitleSortParm = sortOrder == "Title" ? "Title desc" : "Title";
            //ViewBag.GenreSortParm = sortOrder == "Genre" ? "Genre desc" : "Genre";
            //ViewBag.LanguageSortParm = sortOrder == "Language" ? "Language desc" : "Language";
            //ViewBag.ISBNSortParm = sortOrder == "ISBN" ? "ISBN desc" : "ISBN";
            //ViewBag.AuthorsSortParm = sortOrder == "Author/s" ? "Author/s desc" : "Author/s";

            //switch (sortOrder)
            //{
            //    case "Title":
            //        books = books.OrderBy(p => p.Title);
            //        break;
            //    case "Title desc":
            //        books = books.OrderByDescending(p => p.Title);
            //        break;
            //    case "Genre":
            //       books = books.Where(p=>p.Genre != null).OrderBy(p => p.Genre.GenreName).Concat(books.Where(p => p.Genre == null));
            //        break;
            //    case "Genre desc":
            //        books = books.Where(p => p.Genre == null).Concat(books.Where(p => p.Genre != null).OrderByDescending(p => p.Genre.GenreName));
            //        break;
            //    case "Language":
            //        books = books.OrderBy(p => p.Language.LanguageName);
            //        break;
            //    case "Language desc":
            //        books = books.OrderByDescending(p => p.Language.LanguageName);
            //        break;
            //    case "ISBN":
            //        books = books.OrderBy(p => p.ISBN);
            //        break;
            //    case "ISBN desc":
            //        books = books.OrderByDescending(p => p.ISBN);
            //        break;
            //    case "Author/s":                  
            //        books = books.OrderBy(p => p.Authors.OrderBy(a => a.AuthorFirstName).Select(a => a.AuthorFirstName).FirstOrDefault());
            //        foreach (var book in books)
            //        {
            //            book.Authors = book.Authors.OrderBy(m => m.AuthorFirstName).ToList();
            //        }                  
            //        break;
            //    case "Author/s desc":                  
            //        books = books.OrderByDescending(p => p.Authors.OrderByDescending(a => a.AuthorFirstName).Select(a => a.AuthorFirstName).FirstOrDefault());
            //        foreach (var book in books)
            //        {
            //            book.Authors = book.Authors.OrderByDescending(m => m.AuthorFirstName).ToList();
            //        }
            //        break;
            //    default:
            //        books = books.OrderBy(p => p.Title);
            //        break;
            //}


            return View(books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            //int bookId;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //else
            //{
            //    bookId = id.GetValueOrDefault();
            //}
            //Book book = db.Books.Find(id);
            Book book = unitOfWork.BooksRP.GetBookByID(id.GetValueOrDefault());
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(unitOfWork.GenresRP.GetGenres(), "GenreId", "GenreName");
            ViewBag.LanguageId = new SelectList(unitOfWork.LanguagesRP.GetLanguages(), "LanguageId", "LanguageName");
            var book = new Book();
            book.Authors = new List<Author>();
            PopulateAssignedAuthorData(book);
            ViewBag.selAuthors = new MultiSelectList(new[] { "" });
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ISBN,Description,LanguageId,GenreId")] Book book, string[] bookAuthors)
        {
            try
            {
                if (bookAuthors != null)
                {
                    book.Authors = new List<Author>();

                    foreach (var auth in bookAuthors)
                    {
                        var authToAdd = unitOfWork.AuthorsRP.GetAuthorByID(int.Parse(auth));
                        book.Authors.Add(authToAdd);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Something went whrong!");
                }

                if (ModelState.IsValid)
                {
                    unitOfWork.BooksRP.InsertBook(book);
                    unitOfWork.BooksRP.Save();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException e)
            {
                if (e.InnerException.InnerException.Message.Contains("IX_ISBN"))
                {

                    var allAuthors = unitOfWork.AuthorsRP.GetAuthors();
                    var selectedAut = new List<Author>();

                    foreach (var aut in bookAuthors)
                    {
                        var auth = unitOfWork.AuthorsRP.GetAuthorByID(int.Parse(aut));
                        selectedAut.Add(new Author
                        {
                                AuthorId = auth.AuthorId,
                                AuthorFirstName = auth.FullName,                              
                        });
                       
                    }
                   
                    ViewBag.selAuthors = new MultiSelectList(selectedAut.OrderBy(x => x.AuthorFirstName), "AuthorId", "FullName");
                    
                    ModelState.AddModelError("ISBN", "ISBN number must be unique!");

                } else
                {
                    ModelState.AddModelError("", "Unable to create!");
                }              
            }

            ViewBag.GenreId = new SelectList(unitOfWork.GenresRP.GetGenres(), "GenreId", "GenreName", book.GenreId);
            ViewBag.LanguageId = new SelectList(unitOfWork.LanguagesRP.GetLanguages(), "LanguageId", "LanguageName", book.LanguageId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            int bookId;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                bookId = id.GetValueOrDefault();
            }

            Book book = unitOfWork.BooksRP.GetBookWithAuthors(bookId);

            if (book == null)
            {
                return HttpNotFound();
            }

            ViewBag.GenreId = new SelectList(unitOfWork.GenresRP.GetGenres(), "GenreId", "GenreName", book.GenreId);
            ViewBag.LanguageId = new SelectList(unitOfWork.LanguagesRP.GetLanguages(), "LanguageId", "LanguageName", book.LanguageId);
            PopulateAssignedAuthorData(book);

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] bookAuthors)
        {
            int bookId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                bookId = id.GetValueOrDefault();
            }
          
            Book bookToUpdate = unitOfWork.BooksRP.GetBookByID(bookId);

            if (TryUpdateModel(bookToUpdate, "", new string[] { "Id", "Title", "ISBN", "Description", "LanguageId", "GenreId" }))
            {
                UpdateBookAuthor(bookAuthors, bookToUpdate);
                unitOfWork.BooksRP.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(unitOfWork.GenresRP.GetGenres(), "GenreId", "GenreName", bookToUpdate.GenreId);
            ViewBag.LanguageId = new SelectList(unitOfWork.LanguagesRP.GetLanguages(), "LanguageId", "LanguageName", bookToUpdate.LanguageId);
            return View(bookToUpdate);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            int bookId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                bookId = id.GetValueOrDefault();
            }
            Book book = unitOfWork.BooksRP.GetBookByID(bookId);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = unitOfWork.BooksRP.GetBookByID(id);
            unitOfWork.BooksRP.DeleteBook(id);
            unitOfWork.BooksRP.Save();
            return RedirectToAction("Index");
        }

        private void PopulateAssignedAuthorData(Book book)
        {
            var allAuthors = unitOfWork.AuthorsRP.GetAuthors();
            var pAuthor = new HashSet<int>(book.Authors.Select(b => b.AuthorId));
            var viewModelAvailable = new List<BookAuthorsVM>();
            var viewModelSelected = new List<BookAuthorsVM>();

            foreach (var aut in allAuthors)
            {
                if (pAuthor.Contains(aut.AuthorId))
                {
                    viewModelSelected.Add(new BookAuthorsVM
                    {
                        AuthorId = aut.AuthorId,
                        AuthorFirstName = aut.AuthorFirstName,
                        AuthorMiddleName=aut.AuthorMiddleName,
                        AuthorLastName=aut.AuthorLastName
                    });
                }
                else
                {
                    viewModelAvailable.Add(new BookAuthorsVM
                    {
                        AuthorId = aut.AuthorId,
                        AuthorFirstName = aut.AuthorFirstName,
                        AuthorMiddleName = aut.AuthorMiddleName,
                        AuthorLastName = aut.AuthorLastName,
                        
                    });
                }
            }
            ViewBag.selAuthors = new MultiSelectList(viewModelSelected.OrderBy(x => x.AuthorFirstName), "AuthorId", "AuthorFullName");
        }

        private void UpdateBookAuthor(string[] selectedAuthors, Book bookToUpdate)
        {
            if (selectedAuthors == null)
            {
                bookToUpdate.Authors = new List<Author>();
                return;
            }

            var selectedAuthorsHS = new HashSet<string>(selectedAuthors);
            var bookAut = new HashSet<int>
                (bookToUpdate.Authors.Select(c => c.AuthorId));
            foreach (var aut in unitOfWork.AuthorsRP.GetAuthors())
            {
                if (selectedAuthorsHS.Contains(aut.AuthorId.ToString()))
                {
                    if (!bookAut.Contains(aut.AuthorId))
                    {
                        bookToUpdate.Authors.Add(aut);
                    }
                }
                else
                {
                    if (bookAut.Contains(aut.AuthorId))
                    {
                        bookToUpdate.Authors.Remove(aut);
                    }
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.BooksRP.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
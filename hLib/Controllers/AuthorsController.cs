using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using hLib.Models;
using hLib.DAL;

namespace hLib.Controllers
{
    public class AuthorsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new HLibDBContext());

        // GET: Authors
        public ActionResult Index()
        {

            Exception ex = TempData["error"] as Exception;

            if (ex != null)
            {
                ModelState.AddModelError("", "Author assign to book/s and can not be deleted!");
            }
           
            var authors = unitOfWork.AuthorsRP.GetAuthors();
            ViewBag.NationalityId = new SelectList(unitOfWork.NationalitiesRP.GetNationalitys(), "NationalityId", "NationalityName");

            return View(authors.ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            int authorId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                authorId = id.GetValueOrDefault();
            }
            Author author = unitOfWork.AuthorsRP.GetAuthorByID(authorId);
            
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            ViewBag.NationalityId = new SelectList(unitOfWork.NationalitiesRP.GetNationalitys(), "NationalityId", "NationalityName");
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuthorId,AuthorFirstName,AuthorMiddleName,AuthorLastName,NationalityId")] Author author)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.AuthorsRP.InsertAuthor(author);
                unitOfWork.AuthorsRP.Save();
                return RedirectToAction("Index");
            }

            ViewBag.NationalityId = new SelectList(unitOfWork.NationalitiesRP.GetNationalitys(), "NationalityId", "NationalityName", author.NationalityId);
            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            int authorId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                authorId = id.GetValueOrDefault();
            }
            Author author = unitOfWork.AuthorsRP.GetAuthorByID(authorId);
            if (author == null)
            {
                return HttpNotFound();
            }
            ViewBag.NationalityId = new SelectList(unitOfWork.NationalitiesRP.GetNationalitys(), "NationalityId", "NationalityName", author.NationalityId);
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuthorId,AuthorFirstName,AuthorMiddleName,AuthorLastName,NationalityId")] Author author)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.AuthorsRP.UpdateAuthor(author);
                unitOfWork.AuthorsRP.Save();
                return RedirectToAction("Index");
            }
            ViewBag.NationalityId = new SelectList(unitOfWork.NationalitiesRP.GetNationalitys(), "NationalityId", "NationalityName", author.NationalityId);
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            int authorId;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                authorId = id.GetValueOrDefault();
            }
            Author author = unitOfWork.AuthorsRP.GetAuthorByID(authorId);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            Author author = unitOfWork.AuthorsRP.GetAuthorByID(id);
            int numberOfBooks = author.Books.Count;
            if (numberOfBooks == 0)
            {
                unitOfWork.AuthorsRP.DeleteAuthor(id);
                unitOfWork.AuthorsRP.Save();
            }
            else {
                TempData["error"] = new Exception();
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.AuthorsRP.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

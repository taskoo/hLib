using System.Linq;
using System.Net;
using System.Web.Mvc;
using hLib.Models;
using hLib.DAL;

namespace hLib.Controllers
{
    public class GenresController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new HLibDBContext());

        // GET: Genres
        public ActionResult Index()
        {
            var genres = unitOfWork.GenresRP.GetGenres();
            ViewBag.currentPage = "genres";
            return View(genres.ToList());
        }

        //GET: Genres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = unitOfWork.GenresRP.GetGenreByID(id.GetValueOrDefault());
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GenreId,GenreName")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GenresRP.InsertGenre(genre);
                unitOfWork.GenresRP.Save();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GenreId,GenreName")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.GenresRP.UpdateGenre(genre);
                unitOfWork.GenresRP.Save();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.GenresRP.DeleteGenre(id);
            unitOfWork.GenresRP.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.GenresRP.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

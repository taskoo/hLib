using System.Linq;
using System.Web.Mvc;
using hLib.Models;
using hLib.DAL;
using System.Data;
using System;

namespace hLib.Controllers
{
    public class NationalitiesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new HLibDBContext());

        // GET: Nationalities
        public ActionResult Index()
        {
            Exception ex = TempData["error"] as Exception;

            var nationalities = unitOfWork.NationalitiesRP.GetNationalitys();

            if (ex != null)
            {
                ModelState.AddModelError("", "Nationality assigned to author and and cannot be deleted!");
            }

            ViewBag.currentPage = "nationalities";

            return View(nationalities.ToList());
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NationalityId,NationalityName")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.NationalitiesRP.InsertNationality(nationality);
                unitOfWork.NationalitiesRP.Save();
                return RedirectToAction("Index");
            }

            return View(nationality);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NationalityId,NationalityName")] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.NationalitiesRP.UpdateNationality(nationality);
                unitOfWork.NationalitiesRP.Save();
                return RedirectToAction("Index");
            }
            return View(nationality);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                unitOfWork.NationalitiesRP.DeleteNationality(id);
                unitOfWork.NationalitiesRP.Save();
            }
            catch (DataException ex)
            {
                TempData["error"] = ex;
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.NationalitiesRP.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

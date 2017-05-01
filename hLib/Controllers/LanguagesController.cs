using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using hLib.Models;
using hLib.DAL;

namespace hLib.Controllers
{
    public class LanguagesController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new HLibDBContext());

        // GET: Languages
        public ActionResult Index() 
        {
            Exception ex = TempData["error"] as Exception;

            var languages = unitOfWork.LanguagesRP.GetLanguages();
            
            if (ex != null)
            {
                ModelState.AddModelError("", "Language in use and can not be deleted!");
            }

            ViewBag.currentPage = "languages";
            
            return View(languages.ToList());
        }

        // POST: Languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageId,LanguageName")] Language language)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LanguagesRP.InsertLanguage(language);
                unitOfWork.LanguagesRP.Save();
                return RedirectToAction("Index");
            }

            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageId,LanguageName")] Language language)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.LanguagesRP.UpdateLanguage(language);
                unitOfWork.LanguagesRP.Save();
                return RedirectToAction("Index");
            }
            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Language language = unitOfWork.LanguagesRP.GetLanguageByID(id);
            try
            {
                unitOfWork.LanguagesRP.DeleteLanguage(id);
                unitOfWork.LanguagesRP.Save();                          
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
                unitOfWork.LanguagesRP.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

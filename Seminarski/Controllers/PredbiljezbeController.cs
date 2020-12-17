using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seminarski.Models;
using System.Data.Entity;
using System.Net;

namespace Seminarski.Controllers
{
    public class PredbiljezbeController : Controller
    {
        private ApplicationDbContext _context;

        public PredbiljezbeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Predbiljezbe
        public ActionResult Predbiljezbe(string searching)
        {
            var predbiljezbeSeminari =
                _context.Predbiljezbe.Where(x => x.Prezime.Contains(searching) || searching == null)
                                    .Include(x => x.Seminar)
                                    .OrderBy(x => x.Status)
                                    .ThenBy(x => x.Datum)
                                    .ToList();

            return View(predbiljezbeSeminari);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var predbiljezba = _context.Predbiljezbe
                                .Include(x => x.Seminar)
                                .SingleOrDefault(x => x.PredbiljezbaID == id);
            
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            
            return View(predbiljezba);
        }

        //public ActionResult PredbiljezbaDelete(int id)
        //{
        //    var predbiljezba = _context.Predbiljezbe.SingleOrDefault(x => x.PredbiljezbaID == id);

        //    _context.Entry(predbiljezba).State = EntityState.Deleted;
        //    _context.SaveChanges();

        //    return RedirectToAction("Predbiljezbe");
        //}

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            //[Bind(Include = "Datum,PredbiljezbaID,Mobitel,Email,Adresa,Prezime,Ime,Status,SeminarID")] // XSRF Security risk na ovaj način
        Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                predbiljezba.Datum = predbiljezba.Datum;
                predbiljezba.PredbiljezbaID = predbiljezba.PredbiljezbaID;
                predbiljezba.Mobitel = predbiljezba.Mobitel;
                predbiljezba.Email = predbiljezba.Email;
                predbiljezba.Prezime = predbiljezba.Prezime;
                predbiljezba.Ime = predbiljezba.Ime;
                predbiljezba.Status = predbiljezba.Status;
                predbiljezba.SeminarID = predbiljezba.SeminarID;
                

                _context.Entry(predbiljezba).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Predbiljezbe");
            }

            return View(predbiljezba);
        }

        
        public ActionResult DohvatiNepoznato()
        {
            var predbiljezbeSeminari =
                 _context.Predbiljezbe.Include(x => x.Seminar)
                                    .Where(x => x.Status == StatusPredbiljezbe.Nepoznato)
                                    .OrderBy(x => x.Status)
                                    .ThenBy(x => x.Datum)
                                    .ToList();



            return View(predbiljezbeSeminari);
        }

        
        public ActionResult DohvatiPrihvacene()
        {
            var predbiljezbeSeminari =
                _context.Predbiljezbe.Include(x => x.Seminar)
                                    .Where(x => x.Status == StatusPredbiljezbe.Prihvacena)
                                    .OrderBy(x => x.Status)
                                    .ThenBy(x => x.Datum)
                                    .ToList();

            return View(predbiljezbeSeminari);
        }

        
        public ActionResult DohvatiNeprihvacene()
        {
            var predbiljezbeSeminari =
                _context.Predbiljezbe.Include(x => x.Seminar)
                                    .Where(x => x.Status == StatusPredbiljezbe.Neprihvacena)
                                    .OrderBy(x => x.Status)
                                    .ThenBy(x => x.Datum)
                                    .ToList();

            return View(predbiljezbeSeminari);
        }
    }
}
using Seminarski.Models;
using System.Linq;
using System.Web.Mvc;
using Seminarski.Models.Viewmodel;
using System.Data.Entity;

namespace Seminarski.Controllers
{
    public class SeminariController : Controller
    {
        private ApplicationDbContext _context;

        public SeminariController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Seminari(string searching)
        {
            var seminari = _context.Seminari
                            .Where(x => x.Naziv.Contains(searching) || searching == null)
                            .Select(_convert)
                            .ToList();

            return View(seminari);
        }

        public ActionResult SeminarForm(int? id)
        {
            if (id.HasValue)
            {
                var seminar = _context.Seminari.SingleOrDefault(x => x.SeminarID == id);

                return View(_convert(seminar));
            }

            return View();
        }

        public ActionResult SeminarDelete(int id)
        {
            var seminar = _context.Seminari.SingleOrDefault(x => x.SeminarID == id);

            _context.Entry(seminar).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Seminari");
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult SeminarForm(SeminarViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SeminarID != null)
                {
                    // UPDATE
                    var trenutnoStanjeUBazi = _context.Seminari.SingleOrDefault(x => x.SeminarID == model.SeminarID);

                    trenutnoStanjeUBazi.Naziv = model.Naziv;
                    trenutnoStanjeUBazi.Datum = model.Datum;
                    trenutnoStanjeUBazi.Opis = model.Opis;
                    trenutnoStanjeUBazi.BrojPolaznika = model.MaximalniBrojPolaznika;
                    trenutnoStanjeUBazi.JePopunjen = model.JePopunjen;

                    _context.Entry(trenutnoStanjeUBazi).State = EntityState.Modified;
                    _context.SaveChanges();

                    return RedirectToAction("Seminari");
                }
                else
                {
                    // CREATE
                    _context.Seminari.Add(new Seminar
                    {
                        BrojPolaznika = model.MaximalniBrojPolaznika,
                        Datum = model.Datum,
                        JePopunjen = model.JePopunjen,
                        Naziv = model.Naziv,
                        Opis = model.Opis
                    });

                    _context.SaveChanges();

                    return RedirectToAction("Seminari");
                }
            }

            return View(model);
        }

        // Privates

        private SeminarViewModel _convert(Seminar seminar)
        {
            return new SeminarViewModel
            {
                Naziv = seminar.Naziv,
                Opis = seminar.Opis,
                SeminarID = seminar.SeminarID,
                TrenutniBrojPolaznika = _nadjiBrojPolaznika(seminar.SeminarID),
                MaximalniBrojPolaznika = seminar.BrojPolaznika,
                Datum = seminar.Datum,
                JePopunjen = seminar.JePopunjen
            };
        }

        private int _nadjiBrojPolaznika(int seminarID)
        {
            return _context.Predbiljezbe.Count(p => p.SeminarID == seminarID && p.Status == StatusPredbiljezbe.Prihvacena);
        }
    }
}
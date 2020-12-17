using Seminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;


namespace Seminarski.Controllers
{
    [AllowAnonymous]
    public class PredbiljezbaController : Controller
    {
        private ApplicationDbContext _context;

        public PredbiljezbaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Predbiljezba
        public ActionResult Predbiljezba(string searching)
        {
            var seminari = _context.Seminari
                            .Where(x => x.Naziv.Contains(searching) && x.JePopunjen == false || searching == null)
                            .Where(x => x.JePopunjen == false)
                            .ToList();

            return View(seminari);
        }

        public ActionResult New(int id)
        {

            var predbiljezba = new Predbiljezba() { SeminarID = id };

            

            ViewBag.NazivSeminara = _context.Seminari
                                    .Where(x => x.SeminarID == id)
                                    .Select(x => x.Naziv)
                                    .FirstOrDefault();
            
            return View(predbiljezba);
        }

        [HttpPost]
        [HandleError]
        [ValidateAntiForgeryToken]
        public ActionResult New(Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                _context.Predbiljezbe.Add(predbiljezba);
                _context.SaveChanges();

                return RedirectToAction("Predbiljezba" , "Predbiljezba");
            }

            return View();
        }
    }
}
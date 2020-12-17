using Seminarski.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using Seminarski.Models;


namespace Seminarski.Controllers
{
    public class SeminarController : Controller
    {
        private ApplicationDbContext _context;

        public SeminarController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            var seminari = _context.Seminari.ToList();

            var viewModel = _context.Seminari
                .Include(c => c.Predbiljezba)
                .ToList();

            return View(viewModel);
        }
    }
}
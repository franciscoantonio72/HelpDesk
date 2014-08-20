using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelpDesk.Models;

namespace HelpDesk.Controllers
{
    public class OsController : Controller
    {
        private HelpDeskContext db = new HelpDeskContext();

        //
        // GET: /Os/

        public ActionResult Index()
        {
            var os = db.Os.Include(o => o.Cliente).Include(o => o.Tecnico);
            return View(os.ToList());
        }

        //
        // GET: /Os/Details/5

        public ActionResult Details(int id = 0)
        {
            Os os = db.Os.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        //
        // GET: /Os/Create

        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome");
            return View();
        }

        //
        // POST: /Os/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Os os)
        {
            if (ModelState.IsValid)
            {
                db.Os.Add(os);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome", os.TecnicoId);
            return View(os);
        }

        //
        // GET: /Os/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Os os = db.Os.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome", os.TecnicoId);
            return View(os);
        }

        //
        // POST: /Os/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Os os)
        {
            if (ModelState.IsValid)
            {
                db.Entry(os).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome", os.TecnicoId);
            return View(os);
        }

        //
        // GET: /Os/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Os os = db.Os.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        //
        // POST: /Os/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Os os = db.Os.Find(id);
            db.Os.Remove(os);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
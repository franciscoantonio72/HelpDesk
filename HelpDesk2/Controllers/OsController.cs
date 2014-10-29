using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpDesk2.Models;

namespace HelpDesk2.Controllers
{
    public class OsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Os/
        public ActionResult Index()
        {
            var os = db.Os.Include(o => o.Cliente).Include(o => o.Status).Include(o => o.Tecnico);
            return View(os.ToList());
        }

        // GET: /Os/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Os os = db.Os.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

        // GET: /Os/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao");
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome");
            return View();
        }

        // POST: /Os/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Descricao,ClienteId,TecnicoId,Data,Prioridades,StatusId")] Os os)
        {
            if (ModelState.IsValid)
            {
                db.Os.Add(os);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome", os.TecnicoId);
            return View(os);
        }

        // GET: /Os/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Os os = db.Os.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome", os.TecnicoId);
            return View(os);
        }

        // POST: /Os/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Descricao,ClienteId,TecnicoId,Data,Prioridades,StatusId")] Os os)
        {
            if (ModelState.IsValid)
            {
                db.Entry(os).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome", os.TecnicoId);
            return View(os);
        }

        // GET: /Os/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Os os = db.Os.Find(id);
            if (os == null)
            {
                return HttpNotFound();
            }
            return View(os);
        }

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
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

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
    public class TipoServicoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /TipoServico/
        public ActionResult Index()
        {
            return View(db.TipoServicoes.ToList());
        }

        // GET: /TipoServico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServico tiposervico = db.TipoServicoes.Find(id);
            if (tiposervico == null)
            {
                return HttpNotFound();
            }
            return View(tiposervico);
        }

        // GET: /TipoServico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Descricao")] TipoServico tiposervico)
        {
            if (ModelState.IsValid)
            {
                db.TipoServicoes.Add(tiposervico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposervico);
        }

        // GET: /TipoServico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServico tiposervico = db.TipoServicoes.Find(id);
            if (tiposervico == null)
            {
                return HttpNotFound();
            }
            return View(tiposervico);
        }

        // POST: /TipoServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Descricao")] TipoServico tiposervico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposervico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposervico);
        }

        // GET: /TipoServico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoServico tiposervico = db.TipoServicoes.Find(id);
            if (tiposervico == null)
            {
                return HttpNotFound();
            }
            return View(tiposervico);
        }

        // POST: /TipoServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoServico tiposervico = db.TipoServicoes.Find(id);
            db.TipoServicoes.Remove(tiposervico);
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

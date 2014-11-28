using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpDesk2.Models;
using PagedList;

namespace HelpDesk2.Controllers
{
    public class OsController : ApplicationController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Os/
        public ActionResult Index()
        {
            //var os = db.Os.Include(o => o.Cliente).Include(o => o.Status).Include(o => o.Tecnico);
            IEnumerable<Os> listaOs;
            if (UsuarioSessao().Niveis == 0)
            {
                listaOs = db.Os.ToList();    
            }
            else
            {
                listaOs = db.Os.ToList().Where(dado => dado.UserId == UsuarioSessao().Id);
            }
            
            return View(listaOs);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(int? id)
        //{
        //    IEnumerable<Os> listaOs;
        //    if (UsuarioSessao().Niveis == 0)
        //    {
        //        if (id == null)
        //            listaOs = db.Os.ToList();
        //        else
        //            listaOs = db.Os.ToList().Where(dado => dado.Id == id);
        //    }
        //    else
        //    {
        //        if (id == null)
        //            listaOs = db.Os.ToList().Where(dado => dado.UserId == UsuarioSessao().Id);
        //        else
        //            listaOs = db.Os.ToList().Where(dado => dado.UserId == UsuarioSessao().Id && dado.Id == id);
        //    }

        //    return View(listaOs.ToList());
        //}

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
            var lista = db.Nota.Where(l => l.OsId == os.Id).ToList();
            os.Nota = lista;
            return View(os);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Pesquisa(int? id )
        {
            IEnumerable<Os> listaOs;
            if (UsuarioSessao().Niveis == 0)
            {
                if (id == null)
                    listaOs = db.Os.ToList();
                else
                    listaOs = db.Os.ToList().Where(dado => dado.Id == id);
            }
            else
            {
                if (id == null)
                    listaOs = db.Os.ToList().Where(dado => dado.UserId == UsuarioSessao().Id);
                else
                    listaOs = db.Os.ToList().Where(dado => dado.UserId == UsuarioSessao().Id && dado.Id == id);
            }

            return View(listaOs.ToList());
        }

        // GET: /Os/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao");
            ViewBag.TecnicoId = new SelectList(db.Tecnicoes, "Id", "Nome");
            ViewBag.ServicosId = new SelectList(db.Servicoes, "Id", "Nome");
            var usuarios = db.Users.ToList();
            ViewBag.UsersId = new SelectList(usuarios, "Id", "UserName");
            return View();
        }

        // POST: /Os/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Descricao,ClienteId,Data,Prioridades,StatusId,UserId,MsgNota,DataFechamento,HoraAbertura,HoraFechamento")] Os os)
        {
            if (ModelState.IsValid)
            {
                os.Usuario = db.Users.Find(os.UserId).UserName.ToString();
                os.HoraAbertura = DateTime.Now.ToShortTimeString();
                os.Data = DateTime.Now;
                db.Os.Add(os);
                db.SaveChanges();

                Nota lNota = new Nota();
                lNota.Descricao = os.MsgNota;
                lNota.Operador = UsuarioSessao().UserName;
                lNota.OsId = os.Id;
                db.Nota.Add(lNota);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            var usuarios = db.Users.ToList();
            ViewBag.UsersId = new SelectList(usuarios, "Id", "UserName");
            ViewBag.ServicosId = new SelectList(db.Servicoes, "Id", "Nome");

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
            os.MsgNota = "";
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            ViewBag.ServicosId = new SelectList(db.Servicoes, "Id", "Nome");
            var usuarios = db.Users.ToList();
            ViewBag.UsersId = new SelectList(usuarios, "Id", "UserName");
            var lista = db.Nota.Where(l => l.OsId == os.Id).ToList();
            os.Nota = lista;
            return View(os);
        }

        // POST: /Os/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,ClienteId,Data,Prioridades,StatusId,UserId,MsgNota,DataFechamento,HoraAbertura,HoraFechamento")] Os os)
        {
            if (ModelState.IsValid)
            {
                os.Usuario = db.Users.Find(os.UserId).UserName.ToString();
                db.Entry(os).State = EntityState.Modified;
                db.SaveChanges();

                Nota lNota = new Nota();
                lNota.Descricao = os.MsgNota;
                lNota.Operador = UsuarioSessao().UserName;
                lNota.OsId = os.Id;
                db.Nota.Add(lNota);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            var usuarios = db.Users.ToList();
            ViewBag.UsersId = new SelectList(usuarios, "Id", "UserName");
            ViewBag.ServicosId = new SelectList(db.Servicoes, "Id", "Nome");

            return View(os);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Close([Bind(Include = "Id,Descricao,ClienteId,Data,Prioridades,StatusId,UserId,MsgNota,DataFechamento,HoraAbertura,HoraFechamento")] Os os)
        //public ActionResult Close(Os os)
        {
            if (ModelState.IsValid)
            {
                os.Usuario = db.Users.Find(os.UserId).UserName.ToString();
                os.StatusId = 2;
                os.DataFechamento = System.DateTime.Now;
                os.HoraFechamento = System.DateTime.Now.ToString("t");
                //string hora = db.Os.Find(os.Id).HoraAbertura.ToString();
                //os.HoraAbertura = hora; 
                db.Entry(os).State = EntityState.Modified;
                db.SaveChanges();

                Nota lNota = new Nota();
                lNota.Descricao = "Os Fechada" + "\r";
                lNota.Descricao = lNota.Descricao + os.MsgNota;
                lNota.Operador = UsuarioSessao().UserName;
                lNota.OsId = os.Id;
                db.Nota.Add(lNota);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            var usuarios = db.Users.ToList();
            ViewBag.UsersId = new SelectList(usuarios, "Id", "UserName");

            return View(os);
        }

        public ActionResult Close(int? id)
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
            os.MsgNota = "";
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", os.ClienteId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Descricao", os.StatusId);
            var usuarios = db.Users.ToList();
            ViewBag.UsersId = new SelectList(usuarios, "Id", "UserName");
            var lista = db.Nota.Where(l => l.OsId == os.Id).ToList();
            os.Nota = lista;
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

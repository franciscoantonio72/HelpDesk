using HelpDesk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk2.Controllers
{
    public class RelatorioController : ApplicationController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //
        // GET: /Relatorio/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Relatorio()
        {
            var os = db.Os.Where(r => r.StatusId == 2).ToList();
            return View(os);
        }
    }
}
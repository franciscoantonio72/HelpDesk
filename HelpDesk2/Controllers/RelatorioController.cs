using HelpDesk2.Models;
using HelpDesk2.Models.Relatorio;
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

        public ActionResult RelatorioTecnico()
        {
            var listaOs = from os in db.Os
                          where os.StatusId == 2
                          group os by os.Usuario into g
                          select new AtendimentoTecnico { NomeUsuario = g.Key, Contador = g.Count(), ListaOs = g.ToList() };

            return View(listaOs);
        }

        public ActionResult RelatorioAtendimentoPendente()
        {
            //var os = db.Os.Where(r => r.StatusId != 2).ToList();
            var listaOs = from os in db.Os
                          where os.StatusId == 2
                          group os by os.Cliente into g
                          select new AtendimentoTecnico { NomeCliente = g.Key, Contador = g.Count(), ListaOs = g.ToList() };

            return View(listaOs);
        }

        public ActionResult RelatorioTipoServicos()
        {
            //var listaOs = from os in db.Os
            //              join tipoServico in os.Servicos equals 
            //              group os by os.ServicoId
            return View();
        }
    }
}
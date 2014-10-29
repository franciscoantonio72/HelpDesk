using HelpDesk2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk2.Controllers
{
    public class ApplicationController : Controller
    {
        public ApplicationUser UsuarioSessao()
        {
            return (ApplicationUser)Session[" Usuario "];
        }

        public void SalvarUsuarioSessao(ApplicationUser usuarioLogado)
        {
            Session[" Usuario "] = usuarioLogado;
        }

        public Boolean UsuarioEstaLogado()
        {
            return Session["Usuario"] != null;
        }        // GET: /Application/
        public ActionResult Index()
        {
            return View();
        }
	}
}
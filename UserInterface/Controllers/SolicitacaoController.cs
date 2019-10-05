using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserInterface.Controllers
{
    public class SolicitacaoController : Controller
    {
        private ISolicitacaoApplicationService _solicitacao;
        public SolicitacaoController(ISolicitacaoApplicationService solicitacao)
        {
            _solicitacao = solicitacao;
        }
        // GET: Solicitacao
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Adiciona(string solicitacao)
        {

            return Json(solicitacao);
        }
    }
}
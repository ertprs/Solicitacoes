using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class SolicitacaoController : Controller
    {

        private ISolicitacaoApplicationService _solicitacao;

        public SolicitacaoController(ISolicitacaoApplicationService solicitacao)
        {
            _solicitacao = solicitacao;
        }
        // GET: Solicitacap
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult Adiciona(string soli)
        {
            _solicitacao.Adiciona(new Solicitacao());
            return Json(soli);
        }
    }
}
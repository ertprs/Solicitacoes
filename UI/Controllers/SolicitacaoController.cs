using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class SolicitacaoController : Controller
    {
        private ISolicitacaoApplicationService _applicationService;

        public SolicitacaoController(ISolicitacaoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }


        // GET: Solicitacao
        public ActionResult Index()
        {            
            return View();
        }
        [HttpGet]
        public JsonResult CarregarSolicitacoes()
        {
            return Json(_applicationService.ListarSolicitacao(),JsonRequestBehavior.AllowGet);            
        }

        [HttpGet]
        public JsonResult CarregarAtendimento()
        {
            return Json(_applicationService.CarregarAtendimento(), JsonRequestBehavior.AllowGet);
        }
       
        [HttpGet]
        public JsonResult IniciarAtendimento(string idchamado,string idTecnico)
        {
            return Json(_applicationService.IniciarAtendimento(idchamado, idTecnico), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult FinalizarAtendimento(string idchamado, string idTecnico, string equipamento)
        {
            return Json(_applicationService.FinalizarAtendimento(idchamado, idTecnico,equipamento), JsonRequestBehavior.AllowGet);
        }      
    }
}


using System.Collections.Generic;
using Application.Interface;
using Domain;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application
{
    public class SolicitacaoApplicationService : ISolicitacaoApplicationService
    {
        private ISolicitacaoService _solicitacaoService;

        public SolicitacaoApplicationService(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }
        public void Adiciona(Solicitacao solicitacao)
        {
            _solicitacaoService.Adiciona(solicitacao);
        }

        public int FinalizarAtendimento(string idchamado, string idTecnico, string equipamento)
        {
            return _solicitacaoService.FinalizarAtendimento(idchamado, idTecnico,equipamento);
        }

        public int IniciarAtendimento(string idchamado, string idTecnico)
        {
            return _solicitacaoService.IniciarAtendimento(idchamado,idTecnico);
        }

        public List<Solicitacao> ListarSolicitacao()
        {
            return _solicitacaoService.ListarSolicitacao();
        }

        public List<Atendimento> CarregarAtendimento()
        {
            return _solicitacaoService.CarregarAtendimento();
        }
    }
}

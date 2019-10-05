using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Domain.Services
{
   public class SolicitacaoService :ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;
        public SolicitacaoService(ISolicitacaoRepository solicitacaoRepository)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        public void Adiciona(Solicitacao solicitacao)
        {
            _solicitacaoRepository.Adiciona(solicitacao);
        }

        public int FinalizarAtendimento(string idchamado, string idTecnico, string equipamento)
        {
            return _solicitacaoRepository.FinalizarAtendimento(idchamado, idTecnico,equipamento);
        }

        public int IniciarAtendimento(string idchamado, string idTecnico)
        {
            return _solicitacaoRepository.IniciarAtendimento(idchamado, idTecnico);
        }

        public List<Solicitacao> ListarSolicitacao()
        {
            return _solicitacaoRepository.ListarSolicitacao();
        }

        public List<Atendimento> CarregarAtendimento()
        {
            return _solicitacaoRepository.CarregarAtendimento();
        }

    }
}

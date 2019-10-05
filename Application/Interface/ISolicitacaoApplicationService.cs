using Domain;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interface
{
    public interface ISolicitacaoApplicationService
    {
        void Adiciona(Solicitacao solicitacao);
        List<Solicitacao> ListarSolicitacao();
        List<Atendimento> CarregarAtendimento();
        int IniciarAtendimento(string idchamado,string idTecnico);
        int FinalizarAtendimento(string idchamado, string idTecnico, string equipamento);
    }
}

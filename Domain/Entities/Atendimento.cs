using System;

namespace Domain.Entities
{
    public class Atendimento
    {
        public int AtedimentoId { get; set; }
        public int SolicitacaoId { get; set; }
        public int CodigoTecnico { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int TrocaEquipamento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class ParcelaViewModel
    {
        public int Id { get; set; }
        public int IdContrato { get; set; }
        public string NumeroParcela { get; set; }
        public string Valor { get; set; }
        public string Vencimento { get; set; }
        public ContratoViewModel Contrato { get; set; }
        public PagamentoViewModel Pagamento { get; set; }
        public PixViewModel InformacoesPix { get; set; }
    }
}

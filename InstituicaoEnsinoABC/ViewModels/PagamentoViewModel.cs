using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class PagamentoViewModel
    {
        public int Id { get; set; }
        public string DataPagamento { get; set; }
        public string ValorPago { get; set; }
        public string FormaPagamento { get; set; }
        public string PixIdCorrelacao { get; set; }
        public string PixStatus { get; set; }
        public string PixResponse { get; set; }
        public int IdAluno { get; set; }
        public int IdParcela { get; set; }
        public List<ParcelaViewModel> Parcelas { get; set; }
        public AlunoViewModel Aluno { get; set; }
    }
}

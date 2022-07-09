using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.ViewModels
{
    public class ContratoViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string ValorTotal { get; set; }
        public int? NumParcelas { get; set; }
        public int? DiaPagamento { get; set; }
        public string DataInicio { get; set; }
        public string ValorPago { get; set; }
        public string Status { get; set; }
        public List<ParcelaViewModel> Parcelas { get; set; }
    }
}

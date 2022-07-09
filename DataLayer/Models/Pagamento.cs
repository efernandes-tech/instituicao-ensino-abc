using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Models
{
    public partial class Pagamento
    {
        public int Id { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal? ValorPago { get; set; }
        public string FormaPagamento { get; set; }
        public string PixIdCorrelacao { get; set; }
        public string PixStatus { get; set; }
        public string PixResponse { get; set; }
        public int IdAluno { get; set; }
        public int IdParcela { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual Parcela IdParcelaNavigation { get; set; }
    }
}

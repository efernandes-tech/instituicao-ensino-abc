using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Models
{
    public partial class Contrato
    {
        public Contrato()
        {
            ParcelasNavigation = new HashSet<Parcela>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal? ValorTotal { get; set; }
        public int? Parcelas { get; set; }
        public int? DiaPagamento { get; set; }
        public DateTime? DataInicio { get; set; }
        public decimal? ValorPago { get; set; }
        public string Status { get; set; }
        public int IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual ICollection<Parcela> ParcelasNavigation { get; set; }
    }
}

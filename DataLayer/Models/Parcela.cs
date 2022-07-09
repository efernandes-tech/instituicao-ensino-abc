using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Models
{
    public partial class Parcela
    {
        public Parcela()
        {
            Pagamentos = new HashSet<Pagamento>();
        }

        public int Id { get; set; }
        public string NumeroParcela { get; set; }
        public decimal? ValorParcela { get; set; }
        public DateTime? DataVencimento { get; set; }
        public int IdContrato { get; set; }

        public virtual Contrato IdContratoNavigation { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
    }
}

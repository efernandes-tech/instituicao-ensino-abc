using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Contratos = new HashSet<Contrato>();
            Pagamentos = new HashSet<Pagamento>();
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string EnderecoCompleto { get; set; }

        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

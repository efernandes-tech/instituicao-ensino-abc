using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer.Models
{
    public partial class Usuario
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public ulong FlagAdmin { get; set; }
        public int? IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}

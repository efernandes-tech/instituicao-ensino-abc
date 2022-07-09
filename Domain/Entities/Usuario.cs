using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : Entity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int FlagAdmin { get; set; }
    }
}

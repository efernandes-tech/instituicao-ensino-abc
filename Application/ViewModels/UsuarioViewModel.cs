using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Login { get; set; }
        public string Senha { get; set; }
        [Required]
        public string Email { get; set; }
        public int FlagAdmin { get; set; }
    }
}

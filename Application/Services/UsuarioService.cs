using Application.Interfaces;
using Application.ViewModels;
using Auth.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Application.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public List<UsuarioViewModel> Get()
        {
            IEnumerable<Usuario> _usuarios = this.usuarioRepository.GetAll();

            List<UsuarioViewModel> _usuarioViewModels = mapper.Map<List<UsuarioViewModel>>(_usuarios);

            return _usuarioViewModels;
        }

        public bool Post(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id != Guid.Empty)
                throw new Exception("UsuarioId precisa ser vazio");

            Validator.ValidateObject(usuarioViewModel, new ValidationContext(usuarioViewModel), true);

            Usuario _usuario = mapper.Map<Usuario>(usuarioViewModel);
            _usuario.Senha = EncryptSenha(_usuario.Senha);

            this.usuarioRepository.Create(_usuario);

            return true;
        }

        public UsuarioViewModel GetById(string id)
        {
            if ( ! Guid.TryParse(id, out Guid usuarioId))
                throw new Exception("UsuarioId nao e valido");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioId);

            if (_usuario == null)
                throw new Exception("Usuario nao encontrado");

            return mapper.Map<UsuarioViewModel>(_usuario);
        }

        public bool Put(UsuarioViewModel usuarioViewModel)
        {
            if (usuarioViewModel.Id == Guid.Empty)
                throw new Exception("ID invalido");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioViewModel.Id);
            if (_usuario == null)
                throw new Exception("Usuario nao encontrado");

            if (usuarioViewModel.Senha == "") {
                usuarioViewModel.Senha = _usuario.Senha;
            } else {
                usuarioViewModel.Senha = EncryptSenha(usuarioViewModel.Senha);
            }

            _usuario = mapper.Map<Usuario>(usuarioViewModel);

            this.usuarioRepository.Update(_usuario);

            return true;
        }

        public bool Delete(string id)
        {
            if ( ! Guid.TryParse(id, out Guid usuarioId))
                throw new Exception("UsuarioId nao e valido");

            Usuario _usuario = this.usuarioRepository.Find(x => x.Id == usuarioId);

            if (_usuario == null)
                throw new Exception("Usuario nao encontrado");

            return this.usuarioRepository.Delete(_usuario);
        }

        public UsuarioAuthenticateResponseViewModel Authenticate(UsuarioAuthenticateRequestViewModel usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
                throw new Exception("Email/Senha sao obrigatorios.");

            usuario.Senha = EncryptSenha(usuario.Senha);

            Usuario _usuario = this.usuarioRepository.Find(x => x.Email.ToLower() == usuario.Email.ToLower()
                                                    && x.Senha.ToLower() == usuario.Senha.ToLower());
            if (_usuario == null)
                throw new Exception("Usuario nao encontrado");

            return new UsuarioAuthenticateResponseViewModel(mapper.Map<UsuarioViewModel>(_usuario), TokenService.GenerateToken(_usuario));
        }

        private string EncryptSenha(string Senha)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedSenha = sha.ComputeHash(Encoding.UTF8.GetBytes(Senha));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caracter in encryptedSenha)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }
    }
}

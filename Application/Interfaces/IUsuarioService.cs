using Application.ViewModels;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioViewModel> Get();
        bool Post(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel GetById(string id);
        bool Put(UsuarioViewModel usuarioViewModel);
        bool Delete(string id);
        UsuarioAuthenticateResponseViewModel Authenticate(UsuarioAuthenticateRequestViewModel usuario);
    }
}

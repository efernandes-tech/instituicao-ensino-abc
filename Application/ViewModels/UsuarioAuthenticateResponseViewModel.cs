namespace Application.ViewModels
{
    public class UsuarioAuthenticateResponseViewModel
    {
        public UsuarioAuthenticateResponseViewModel(UsuarioViewModel usuario, string token)
        {
            this.Usuario = usuario;
            this.Token = token;
        }

        public UsuarioViewModel Usuario { get; set; }
        public string Token { get; set; }
    }
}
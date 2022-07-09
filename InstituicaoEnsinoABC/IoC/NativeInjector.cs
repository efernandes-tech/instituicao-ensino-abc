using Application.Interfaces;
using Application.Services;
using DataLayer.Repositories;
using Domain.Interfaces;
using InstituicaoEnsinoABC.Services;
using InstituicaoEnsinoABC.Services.ApiClient;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<ClientCommunicationService>();
            services.AddScoped<ContratoService>();
            services.AddScoped<AlunoService>();
            services.AddScoped<PagamentoService>();

            #endregion

            #region Repositories

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }
    }
}

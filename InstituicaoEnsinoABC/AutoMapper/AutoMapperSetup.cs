using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UsuarioViewModel, Usuario>();

            #endregion

            #region DomainToViewModel

            CreateMap<Usuario, UsuarioViewModel>();

            #endregion
        }
    }
}

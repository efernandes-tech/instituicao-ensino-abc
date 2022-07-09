using DataLayer.Models;
using InstituicaoEnsinoABC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstituicaoEnsinoABC.DTO
{
    public static class AlunoDTO
    {
        public static AlunoViewModel AlunoDataTransferObject(Aluno aluno)
        {
            AlunoViewModel alunoViewModel = new AlunoViewModel
            {
                Id = aluno.Id,
                NomeCompleto = aluno.NomeCompleto,
                Cpf = aluno.Cpf,
                DataNascimento = aluno.DataNascimento?.ToString("yyyy-MM-dd"),
                EnderecoCompleto = aluno.EnderecoCompleto,
            };

            return alunoViewModel;
        }

    }
}
